using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for OfferWindow.xaml
    /// </summary>
    public partial class OfferWindow : Window
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;

        private CompanyDto _selectedCompanyDto;
        private MaterialDto _selectedMaterialDto;
        private OfferDto _currentOffer;

        public OfferWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid? id = null)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();
            if (id.HasValue)
            {
                LoadOffer(id.Value);
            }
            else
            {
                Title = "New offer";
            }
        }

        private void LoadOffer(Guid id)
        {
            try
            {
                _currentOffer = _serviceContext.OfferService.GetById(id);
                SetSelectedMaterial(_currentOffer.Material);
                SetSelectedCompany(_currentOffer.Company);
                Unit.Text = _currentOffer.Unit;
                UnitPrice.Text = _currentOffer.UnitPrice.ToString(CultureInfo.CurrentCulture);
                Comments.Text = _currentOffer.Comments;
                Title = $"Offer of {_currentOffer.MaterialName} material and {_currentOffer.CompanyName} company";
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
                Close();
            }
        }

        private void OnCompanySelect(object sender, RoutedEventArgs e)
        {
            var selectCompanyDialog = new SelectCompanyDialog(_serviceContext, _selectedCompanyDto);
            var dialogResult = selectCompanyDialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                SetSelectedCompany(selectCompanyDialog.SelectedCompanyDto);
            }
        }

        private void SetSelectedCompany(CompanyDto companyDto)
        {
            _selectedCompanyDto = companyDto;
            CompanyLabel.Content = companyDto.Name;
        }

        private void OnMaterialSelect(object sender, RoutedEventArgs e)
        {
            var selectMaterialDialog = new SelectMaterialDialog(_serviceContext, _selectedCompanyDto);
            var dialogResult = selectMaterialDialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                SetSelectedMaterial(selectMaterialDialog.SelectedMaterialDto);
            }
        }

        private void SetSelectedMaterial(MaterialDto materialDto)
        {
            _selectedMaterialDto = materialDto;
            MaterialLabel.Content = materialDto.Name;
        }

        private void PriceCheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utils.NumberRegex.IsMatch(e.Text);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(UnitPrice.Text, out var unitPrice))
            {
                unitPrice = -1m;
            }
            var operationDto = OfferOperationDto.Builder()
                .Comments(Comments.Text)
                .CompanyId(_selectedCompanyDto?.Id ?? Guid.Empty)
                .MaterialId(_selectedMaterialDto?.Id ?? Guid.Empty)
                .Unit(Unit.Text)
                .UnitPrice(unitPrice)
                .Build();
            try
            {
                if (_currentOffer == null &&
                    !Utils.ShowInputErrorMessage(_validatorContext.OfferAddDtoValidator.Validate(operationDto)))
                {
                    new ServiceTransactionProxy<OfferOperationDto, OfferDto>(_serviceContext.OfferService)
                        .Add(operationDto);
                    Close();
                }
                else if (_currentOffer != null &&
                         !Utils.ShowInputErrorMessage(_validatorContext.OfferEditDtoValidator.Validate(operationDto)))
                {
                    _serviceContext.OfferService.Update(_currentOffer.Id, operationDto);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
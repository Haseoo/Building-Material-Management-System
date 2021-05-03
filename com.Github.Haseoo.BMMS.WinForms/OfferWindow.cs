using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class OfferWindow : Form
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;
        private readonly OfferDto _currentOffer;

        private Guid _selectedCompanyId;
        private Guid _selectedMaterialId;

        public OfferWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid? id = null)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();
            if (id != null)
            {
                _currentOffer = _serviceContext.OfferService.GetById(id.Value);
                Unit.Text = _currentOffer.Unit;
                UnitPrice.Text = _currentOffer.UnitPrice.ToString(CultureInfo.CurrentCulture);
                Comments.Text = _currentOffer.Comments;
                _selectedCompanyId = _currentOffer.Company.Id;
                CompanyLabel.Text = _currentOffer.Company.Name;
                _selectedMaterialId = _currentOffer.Material.Id;
                MaterialLabel.Text = _currentOffer.Material.Name;
            }
        }

        private void OnCancelBtnClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void OnCompanySelect(object sender, EventArgs e)
        {
            var companySelector = new SelectCompanyDialog(_serviceContext, _selectedCompanyId);
            companySelector.ShowDialog();
            if (companySelector.DialogResult == DialogResult.OK)
            {
                _selectedCompanyId = companySelector.SelectedCompany.Id;
                CompanyLabel.Text = companySelector.SelectedCompany.Name;
            }
        }

        private void OnMaterialSelect(object sender, EventArgs e)
        {
            var materialSelector = new SelectMaterialDialog(_serviceContext, _selectedCompanyId);
            materialSelector.ShowDialog();
            if (materialSelector.DialogResult == DialogResult.OK)
            {
                _selectedMaterialId = materialSelector.SelectedMaterial.Id;
                MaterialLabel.Text = materialSelector.SelectedMaterial.Name;
            }
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            if (!decimal.TryParse(UnitPrice.Text, out var unitPrice))
            {
                unitPrice = -1m;
            }
            var operationDto = OfferOperationDto.Builder()
                .Comments(Comments.Text)
                .CompanyId(_selectedCompanyId)
                .MaterialId(_selectedMaterialId)
                .Unit(Unit.Text)
                .UnitPrice(unitPrice)
                .Build();
            try
            {
                if (_currentOffer == null &&
                    !Utils.ShowInputErrorMessage(_validatorContext.OfferAddDtoValidator.Validate(operationDto)))
                {
                    new TransactionalService<OfferOperationDto, OfferDto>(_serviceContext.OfferService)
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
    }
}
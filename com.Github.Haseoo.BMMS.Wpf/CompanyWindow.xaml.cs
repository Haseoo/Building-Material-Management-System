using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using NHibernate.Linq;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;

        private readonly ObservableCollection<CompanyContactDataOperationDto> _contactDataDtos =
            new ObservableCollection<CompanyContactDataOperationDto>();

        private readonly CompanyDto _currentCompany;

        public CompanyWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid? id = null)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();

            ContactData.ItemsSource = _contactDataDtos;
            if (id.HasValue)
            {
                try
                {
                    _currentCompany = _serviceContext.CompanyService.GetById(id.Value);
                    DisplayCompanyDto();
                }
                catch (Exception e)
                {
                    Utils.ShowErrorMessage(e);
                    Close();
                }
            }
            else
            {
                OffersBtn.Visibility = Visibility.Hidden;
            }
        }

        private void DisplayCompanyDto()
        {
            CompanyName.Text = _currentCompany.Name;
            Address.Text = _currentCompany.Address;
            City.Text = _currentCompany.City;
            Voivodeship.Text = _currentCompany.Voivodeship;
            _currentCompany.ContactData
                .Select(convertContactDataDto)
                .ForEach(_contactDataDtos.Add);
        }

        private CompanyContactDataOperationDto convertContactDataDto(CompanyContactDataDto dto)
        {
            return CompanyContactDataOperationDto.Builder()
                .Description(dto.Description)
                .EmailAddress(dto.EmailAddress)
                .PhoneNumber(dto.PhoneNumber)
                .RepresentativeNameAndSurname(dto.RepresentativeNameAndSurname)
                .Build();
        }

        private void OnContactDataAdd(object sender, RoutedEventArgs e)
        {
            var dialog = new ContactDataWindow(_validatorContext);
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                _contactDataDtos.Add(dialog.CompanyContactDataOperationDto);
            }
        }

        private void OnDataGridKeyPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete) return;
            OnEntryDelete(sender, e);
        }

        private void OnEntryDelete(object sender, RoutedEventArgs e)
        {
            var selected = GetSelectedDto();
            if (selected != null)
            {
                _contactDataDtos.Remove(selected);
            }
        }

        private CompanyContactDataOperationDto GetSelectedDto()
        {
            return ContactData.SelectedItem as CompanyContactDataOperationDto;
        }

        private void OnEntryEdit(object sender, RoutedEventArgs e)
        {
            var selected = GetSelectedDto();
            if (selected == null) return;
            var dialog = new ContactDataWindow(_validatorContext, selected);
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                _contactDataDtos.Remove(selected);
                _contactDataDtos.Add(dialog.CompanyContactDataOperationDto);
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            var operation = GetFormData();
            if (_currentCompany == null &&
                Utils.ShowInputErrorMessage(_validatorContext.CompanyAddDtoValidator
                    .Validate(operation)))
            {
                return;
            }
            if (_currentCompany != null &&
                Utils.ShowInputErrorMessage(_validatorContext.CompanyEditDtoValidator
                    .Validate(operation)))
            {
                return;
            }
            try
            {
                if (_currentCompany == null)
                {
                    new ServiceTransactionProxy<CompanyOperationDto, CompanyDto>(_serviceContext.CompanyService)
                        .Add(operation);
                }
                else
                {
                    _serviceContext.CompanyService.Update(_currentCompany.Id, operation);
                }

                Close();
            }
            catch (Exception exception)
            {
                Utils.ShowErrorMessage(exception);
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();
        }

        private CompanyOperationDto GetFormData()
        {
            var builder = CompanyOperationDto.Builder();
            foreach (var item in _contactDataDtos)
            {
                builder.ContactData(item);
            }

            return builder
                .Name(CompanyName.Text)
                .City(City.Text)
                .Voivodeship(Voivodeship.Text)
                .Address(Address.Text)
                .Build();
        }
    }
}
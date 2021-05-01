using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using System;
using System.Linq;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class CompanyWindow : Form
    {
        private readonly ValidatorContext _validatorContext;
        private readonly ServiceContext _serviceContext;
        private readonly CompanyDto _currentCompanyDto;

        public CompanyWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid? id = null)
        {
            _validatorContext = validatorContext;
            _serviceContext = serviceContext;
            InitializeComponent();
            ShowOffersBtn.Visible = id != null;
            if (id != null)
            {
                _currentCompanyDto = _serviceContext.CompanyService.GetById(id.Value);
                CompanyName.Text = _currentCompanyDto.Name;
                Address.Text = _currentCompanyDto.Address;
                City.Text = _currentCompanyDto.City;
                Voivodeship.Text = _currentCompanyDto.Voivodeship;
                ContactDataList.SetObjects(_currentCompanyDto.ContactData
                    .Select(e => CompanyContactDataOperationDto.Builder()
                        .RepresentativeNameAndSurname(e.RepresentativeNameAndSurname)
                        .EmailAddress(e.EmailAddress)
                        .PhoneNumber(e.PhoneNumber)
                        .Description(e.Description)
                        .Build())
                    .ToList());
            }
        }

        private void OnContactDataAddBtnClick(object sender, System.EventArgs e)
        {
            var dialog = new ContactDataDialog(_validatorContext);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var result = dialog.Result;
                ContactDataList.AddObject(result);
            }
        }

        private void OnContactDataEditBtnClick(object sender, System.EventArgs e)
        {
            if (ContactDataList.SelectedObject == null)
            {
                return;
            }
            var selected = (CompanyContactDataOperationDto)ContactDataList.SelectedObject;
            var dialog = new ContactDataDialog(_validatorContext, selected);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ContactDataList.RemoveObject(ContactDataList.SelectedObject);
                var result = dialog.Result;
                ContactDataList.AddObject(result);
            }
        }

        private void OnRemoveContactData(object sender, System.EventArgs e)
        {
            if (ContactDataList.SelectedObject != null)
            {
                ContactDataList.RemoveObject(ContactDataList.SelectedObject);
            }

            if (ContactDataList.SelectedObjects != null)
            {
                ContactDataList.RemoveObjects(ContactDataList.SelectedObjects);
            }
        }

        private void OnShowOffers(object sender, EventArgs e)
        {
            new OfferListWindow(_serviceContext, _validatorContext, Utils.OfferListMode.Company, _currentCompanyDto.Id).Show();
        }

        private void OnCancelBtnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            var operation = GetFormData();
            if (_currentCompanyDto == null &&
                Utils.ShowInputErrorMessage(_validatorContext.CompanyOperationDtoValidator
                    .Validate(operation)))
            {
                return;
            }
            if (_currentCompanyDto != null &&
                Utils.ShowInputErrorMessage(_validatorContext.CompanyOperationDtoValidator
                    .Validate(operation)))
            {
                return;
            }
            try
            {
                if (_currentCompanyDto == null)
                {
                    new ServiceTransactionProxy<CompanyOperationDto, CompanyDto>(_serviceContext.CompanyService)
                        .Add(operation);
                }
                else
                {
                    _serviceContext.CompanyService.Update(_currentCompanyDto.Id, operation);
                }

                Close();
            }
            catch (Exception exception)
            {
                Utils.ShowErrorMessage(exception);
            }
        }

        private CompanyOperationDto GetFormData()
        {
            var builder = CompanyOperationDto.Builder();
            if (ContactDataList.Objects != null)
            {
                foreach (var item in ContactDataList.Objects)
                {
                    builder.ContactData((CompanyContactDataOperationDto)item);
                }
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
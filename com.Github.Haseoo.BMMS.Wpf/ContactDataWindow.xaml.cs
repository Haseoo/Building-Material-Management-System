using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators;
using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for ContactDataWindow.xaml
    /// </summary>
    public partial class ContactDataWindow : Window
    {
        private readonly ValidatorContext _validatorContext;

        public CompanyContactDataOperationDto CompanyContactDataOperationDto { get; private set; }

        public ContactDataWindow(ValidatorContext validatorContext, CompanyContactDataOperationDto dto = null)
        {
            _validatorContext = validatorContext;
            InitializeComponent();
            if (dto != null)
            {
                Description.Text = dto.Description;
                NameAndSurname.Text = dto.RepresentativeNameAndSurname;
                EmailAddress.Text = dto.EmailAddress;
                PhoneNumber.Text = dto.PhoneNumber;
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            CompanyContactDataOperationDto = CompanyContactDataOperationDto.Builder()
                .Description(Description.Text)
                .RepresentativeNameAndSurname(NameAndSurname.Text)
                .PhoneNumber(PhoneNumber.Text)
                .EmailAddress(EmailAddress.Text)
                .Build();
            if (Utils.ShowInputErrorMessage(
                _validatorContext.CompanyContactDataValidator.Validate(CompanyContactDataOperationDto)))
            {
                return;
            }
            DialogResult = true;
            Close();
        }
    }
}
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class ContactDataDialog : Form
    {
        private readonly ValidatorContext _validatorContext;
        public CompanyContactDataOperationDto Result { get; private set; }

        public ContactDataDialog(ValidatorContext validatorContext,
            CompanyContactDataOperationDto data = null)
        {
            _validatorContext = validatorContext;
            InitializeComponent();
            AcceptButton = SaveBtn;
            CancelButton = CancelBtn;
            if (data != null)
            {
                Description.Text = data.Description;
                RepresentativeNameAndSurname.Text = data.RepresentativeNameAndSurname;
                EmailAddress.Text = data.EmailAddress;
                PhoneNumber.Text = data.PhoneNumber;
            }
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var formResult = GetFormData();
            if (Utils.ShowInputErrorMessage(_validatorContext.CompanyContactDataValidator.Validate(formResult)))
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                Result = formResult;
                DialogResult = DialogResult.OK;
            }
        }

        private void OnCancel(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private CompanyContactDataOperationDto GetFormData()
        {
            return CompanyContactDataOperationDto.Builder()
                .Description(Description.Text)
                .RepresentativeNameAndSurname(RepresentativeNameAndSurname.Text)
                .EmailAddress(EmailAddress.Text)
                .PhoneNumber(PhoneNumber.Text)
                .Build();
        }
    }
}

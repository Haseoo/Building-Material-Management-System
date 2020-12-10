using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class ContactDataDialog : Form
    {
        public ContactDataDialog()
        {
            InitializeComponent();
            this.AcceptButton = SaveBtn;
            this.CancelButton = CancelBtn;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

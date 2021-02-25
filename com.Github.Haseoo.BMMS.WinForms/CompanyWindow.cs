using System.Windows.Forms;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class CompanyWindow : Form
    {
        private readonly ValidatorContext _validatorContext;

        public CompanyWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext)
        {
            _validatorContext = validatorContext;
            InitializeComponent();
        }

        private void OnContactDataAddBtnClick(object sender, System.EventArgs e)
        {
            var dialog = new ContactDataDialog(_validatorContext);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ContactDataList.AddObject(dialog.Result);
            }
        }

        private void OnContactDataEditBtnClick(object sender, System.EventArgs e)
        {
            if (ContactDataList.SelectedObject == null)
            {
                return;
            }
            var selected = (CompanyContactDataOperationDto) ContactDataList.SelectedObject;
            var dialog = new ContactDataDialog(_validatorContext, selected);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ContactDataList.RemoveObject(selected);
                ContactDataList.AddObject(dialog.Result);
            }
        }

        private void OnRemoveContactData(object sender, System.EventArgs e)
        {
            if (ContactDataList.SelectedObject != null)
            {
                ContactDataList.RemoveObject(ContactDataList.SelectedObject);
            }
        }
    }
}

using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class SelectCompanyDialog : Form
    {
        public CompanyDto SelectedCompany { get; private set; }

        public SelectCompanyDialog(ServiceContext serviceContext,
            Guid? id = null)
        {
            InitializeComponent();
            AcceptButton = SelectBtn;
            CancelButton = CancelBtn;
            var objectList = serviceContext.CompanyService.GetList();
            CompanyList.SetObjects(objectList);
            if (id != null)
            {
                var objToSelect = objectList.ToList().Find(e => e.Id.Equals(id));
                if (objToSelect != null)
                {
                    CompanyList.SelectObject(objToSelect);
                }
            }
        }

        private void OnSelect(object sender, System.EventArgs e)
        {
            var selected = (CompanyDto)CompanyList.SelectedObject;
            if (selected == null)
            {
                DialogResult = DialogResult.None;
                return;
            }

            SelectedCompany = selected;
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
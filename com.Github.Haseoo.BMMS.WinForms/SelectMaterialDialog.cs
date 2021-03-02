using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class SelectMaterialDialog : Form
    {
        public MaterialDto SelectedMaterial { get; private set; }
        public SelectMaterialDialog(ServiceContext serviceContext,
            Guid? id)
        {
            InitializeComponent();
            AcceptButton = SelectBtn;
            CancelButton = CancelBtn;
            var objectList = serviceContext.MaterialService.GetList();
            MaterialList.SetObjects(objectList);
            if (id != null)
            {
                var selected = objectList.ToList().Find(e => e.Id.Equals(id));
                if (selected != null)
                {
                    MaterialList.SelectObject(selected);
                }
            }
        }

        private void OnSelectBtnClick(object sender, System.EventArgs e)
        {
            var selected = (MaterialDto)MaterialList.SelectedObject;
            if (selected == null)
            {
                DialogResult = DialogResult.None;
                return;
            }

            SelectedMaterial = selected;
            DialogResult = DialogResult.OK;
        }

        private void OnCancelBtnClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

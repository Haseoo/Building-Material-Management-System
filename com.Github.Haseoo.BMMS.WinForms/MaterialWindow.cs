using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.WinForms.Configuration;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class MaterialWindow : Form
    {
        private readonly ServiceContext _serviceContext;
        private readonly MaterialDto _material;
        private readonly ValidatorContext _validatorContext;

        public MaterialWindow(Guid? materialId=null)
        {
            _validatorContext = new ValidatorContext();
            _serviceContext = new ServiceContext( MapperConf.Mapper);
            InitializeComponent();
            if (materialId == null) {
                Text = "Add new material";
                ShowOffers.Visible = false;
            } else
            {
                try {
                    _material = _serviceContext.MaterialService.GetById(materialId.Value);
                    Text = $"Editing {_material.Name}";
                    NameInput.Text = _material.Name;
                    SpecificationInput.Text = _material.Specification;
                }
                catch (Exception e)
                {
                    Utils.ShowErrorMessage(e);
                    Close();
                }
            }

        }

        private void OnCancel(object sender, System.EventArgs e)
        {
            Close();
        }

        private void OnSave(object sender, EventArgs e)
        {
            var operation = MaterialOperationDto
                .Builder()
                .Name(NameInput.Text)
                .Specification(SpecificationInput.Text)
                .Build();
            try
            {
                if(_material != null)
                {
                    if (Utils.ShowInputErrorMessage(_validatorContext.MaterialEditDtoValidator.Validate(operation)))
                    {
                        return;
                    }
                    _serviceContext.MaterialService.Update(_material.Id, operation);
                }
                else
                {
                    if (Utils.ShowInputErrorMessage(_validatorContext.MaterialAddDtoValidator.Validate(operation)))
                    {
                        return;
                    }
                    _serviceContext.MaterialService.Add(operation);
                }
                Close();
            }
            catch(Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }
    }
}

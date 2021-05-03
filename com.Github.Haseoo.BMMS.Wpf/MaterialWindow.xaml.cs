using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using System;
using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for MaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window
    {
        private readonly Guid? _materialId;
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;

        public MaterialWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid? id = null)
        {
            InitializeComponent();
            _materialId = id;
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            if (_materialId == null)
            {
                Title = "New material";
                ShowOfferBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                LoadMaterial(_materialId.Value);
            }
        }

        private void LoadMaterial(Guid id)
        {
            try
            {
                var material = _serviceContext.MaterialService.GetById(id);
                MaterialName.Text = material.Name;
                MaterialSpecification.Text = material.Specification;
                Title = material.Name;
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
                Close();
            }
        }

        private void OnShowOffer(object sender, RoutedEventArgs e)
        {
            if (_materialId.HasValue)
            {
                new OfferListWindow(_serviceContext, _validatorContext, Utils.OfferListMode.Material, _materialId.Value)
                    .Show();
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            var operation = MaterialOperationDto.Builder()
                .Name(MaterialName.Text)
                .Specification(MaterialSpecification.Text)
                .Build();
            try
            {
                if (_materialId != null)
                {
                    if (Utils.ShowInputErrorMessage(_validatorContext.MaterialEditDtoValidator.Validate(operation)))
                    {
                        return;
                    }
                    _serviceContext.MaterialService.Update(_materialId.Value, operation);
                }
                else
                {
                    if (Utils.ShowInputErrorMessage(_validatorContext.MaterialAddDtoValidator.Validate(operation)))
                    {
                        return;
                    }
                    new TransactionalService<MaterialOperationDto, MaterialDto>(_serviceContext.MaterialService)
                        .Add(operation);
                }
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }
    }
}
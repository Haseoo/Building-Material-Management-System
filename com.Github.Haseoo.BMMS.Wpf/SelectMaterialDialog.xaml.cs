using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using System;
using System.Linq;
using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for SelectMaterialDialog.xaml
    /// </summary>
    public partial class SelectMaterialDialog : Window
    {
        public MaterialDto SelectedMaterialDto { get; private set; }

        public SelectMaterialDialog(ServiceContext serviceContext, CompanyDto selected = null)
        {
            InitializeComponent();
            try
            {
                var materials = serviceContext.MaterialService.GetList();
                Materials.ItemsSource = materials;
                if (selected != null)
                {
                    Materials.SelectedItem = materials.FirstOrDefault(c => c.Id.Equals(selected.Id));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
                Close();
            }
        }

        private void OnMaterialSelect(object sender, EventArgs e)
        {
            if (!(Materials.SelectedItem is MaterialDto selected))
            {
                return;
            }
            SelectedMaterialDto = selected;
            DialogResult = true;
            Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
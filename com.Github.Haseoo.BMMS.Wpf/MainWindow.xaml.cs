using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Validators;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;

        public MainWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();
            Materials.ItemsSource = serviceContext.MaterialService.GetList();
            Companies.ItemsSource = serviceContext.CompanyService.GetList();
        }

        private void OnCompanyAdd(object sender, RoutedEventArgs e)
        {
            new CompanyWindow().Show();
        }

        private void OnMaterialAdd(object sender, RoutedEventArgs e)
        {
            new MaterialWindow().Show();
        }

        private void OnOfferAdd(object sender, RoutedEventArgs e)
        {
            new OfferWindow().Show();
        }

        private void OnMaterialSearchOrRefresh(object sender, RoutedEventArgs e)
        {
            
        }

        private List<CompanyDto> LoadCompanies()
        {
            return new List<CompanyDto>();
        }

        private void OnRowDoubleClick(object sender, RoutedEventArgs e)
        {
            if (CompaniesTab.IsSelected)
            {
                MessageBox.Show(((CompanyDto) Companies.SelectedValue).Name);
            } else if (MaterialsTab.IsSelected)
            {
                MessageBox.Show(((MaterialDto) Materials.SelectedValue).Name);
            }
        }
    }
}

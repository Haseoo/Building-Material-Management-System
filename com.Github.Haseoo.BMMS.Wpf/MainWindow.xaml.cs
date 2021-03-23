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

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<MaterialDto> MaterialList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MaterialList = new List<MaterialDto>();
            Materials.ItemsSource = MaterialList;
            Companies.ItemsSource = LoadCompanies();
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

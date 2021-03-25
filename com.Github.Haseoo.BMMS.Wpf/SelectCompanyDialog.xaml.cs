using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using NHibernate.Util;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for SelectCompanyDialog.xaml
    /// </summary>
    public partial class SelectCompanyDialog : Window
    {
        public CompanyDto SelectedCompanyDto { get; private set; }
        public SelectCompanyDialog(ServiceContext serviceContext, CompanyDto selected = null)
        {
            InitializeComponent();
            try
            {
                var companies = serviceContext.CompanyService.GetList();
                Companies.ItemsSource = companies;
                if (selected != null)
                {
                    Companies.SelectedItem = companies.FirstOrDefault(c => c.Id.Equals(selected.Id));
                }
            } catch(Exception ex)
            {
                Utils.ShowErrorMessage(ex);
                Close();
            }

        }

        private void OnCompanySelect(object sender, EventArgs e)
        {
            if (!(Companies.SelectedItem is CompanyDto selected))
            {
                return;
            }
            SelectedCompanyDto = selected;
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

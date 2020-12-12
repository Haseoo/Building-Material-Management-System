using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTabChange(object sender, EventArgs e)
        {
        }

        private void OnQuit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMaterialAdd(object sender, EventArgs e)
        {
            new MaterialWindow().Show();
        }

        private void OnSearchCompany(object sender, EventArgs e)
        {
            
        }

        private void RefreshCompanies(object sender, EventArgs e)
        {

        }

        private void OnSearchMaterial(object sender, EventArgs e)
        {

        }

        private void RefreshMaterials(object sender, EventArgs e)
        {

        }

        private void OnAddCompany(object sender, EventArgs e)
        {
            new CompanyWindow().Show();
        }

        private void OnAddOffer(object sender, EventArgs e)
        {
            new OfferWindow().Show();
        }
    }
}

using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.WinForms.Configuration;
using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class MainWindow : Form
    {
        public MainWindow( )
        {
            InitializeComponent();
            _serviceContext = new ServiceContext(SessionFactoryBuilder.BuildSessionFactory(), MapperConf.Mapper);
            RefreshMaterials();
        }

        private ServiceContext _serviceContext;

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

        private void RefreshMaterials(object sender = null, EventArgs e = null)
        {
            MaterialList.SetObjects(_serviceContext.MaterialService.GetList());
        }

        private void OnAddCompany(object sender, EventArgs e)
        {
            new CompanyWindow().Show();
        }

        private void OnAddOffer(object sender, EventArgs e)
        {
            new OfferWindow().Show();
        }

        private void OnMaterialActivated(object sender, EventArgs e)
        {
        }
    }
}

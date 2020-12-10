using com.Github.Haseoo.BMMS.Business.DTOs;
using System;
using System.Collections.Generic;
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
            MessageBox.Show("Tab changed!");
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
    }
}

using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.WinForms.Configuration;
using System;
using System.Windows.Forms;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class MainWindow : Form
    {
        private bool _isCompany = true;
        public MainWindow( )
        {
            InitializeComponent();
            _serviceContext = new ServiceContext(MapperConf.Mapper);
            RefreshMaterials();
        }

        private readonly ServiceContext _serviceContext;

        private void OnTabChange(object sender, EventArgs e)
        {
            _isCompany = !_isCompany;
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
            try
            {
                var selected = (MaterialDto)MaterialList.SelectedObject;
                new MaterialWindow(selected.Id).Show();
            }
            catch (BusinessLogicException exception)
            {
                Utils.ShowErrorMessage(exception);
            }
        }

        private void OnMaterialSearchOrRefresh(object sender, EventArgs e)
        {
            string partialName = MaterialSearchField.Text;
            if (string.IsNullOrWhiteSpace(partialName))
            {
                RefreshMaterials();
            } else
            {
                MaterialList.SetObjects(_serviceContext.MaterialService.SearchByName(partialName));
            }
        }

        private void OnEditToolTip(object sender, EventArgs e)
        {
            if (_isCompany)
            {

            }
            else
            {
                if (MaterialList.SelectedObject != null)
                {
                    OnMaterialActivated(sender, e);
                }
            }
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            OnMaterialSearchOrRefresh(sender, e);
        }

        private void OnEntryRemove(object sender, EventArgs e)
        {
            try
            {
                if (_isCompany)
                {

                }
                else
                {
                    var selected = (MaterialDto)MaterialList.SelectedObject;
                    if (selected != null)
                    {
                        new ServiceTransactionProxy<MaterialOperationDto, MaterialDto>(_serviceContext.MaterialService)
                            .Delete(selected.Id);
                        RefreshMaterials(sender, e);
                    }
                }
            }
            catch (BusinessLogicException ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }
    }
}

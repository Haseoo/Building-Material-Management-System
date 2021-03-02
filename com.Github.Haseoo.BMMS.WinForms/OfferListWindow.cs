using System;
using System.Windows.Forms;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Data;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class OfferListWindow : Form
    {
        private readonly ServiceContext _serviceContext;
        private readonly Utils.OfferListMode _mode;
        private readonly Guid _id;

        public OfferListWindow(ServiceContext serviceContext,
            Utils.OfferListMode mode,
            Guid id)
        {
            _serviceContext = serviceContext;
            _mode = mode;
            _id = id;
            SessionManager.Instance.AcquireNewSession();
            InitializeComponent();
            RefreshOffers();
        }

        private void RefreshOffers(object sender=null, System.EventArgs e=null)
        {
            switch (_mode)
            {
                case Utils.OfferListMode.Company:
                    OfferList.SetObjects(_serviceContext.OfferService.GetCompanyOffers(_id));
                    break;
                case Utils.OfferListMode.Material:
                    OfferList.SetObjects(_serviceContext.OfferService.GetMaterialOffers(_id));;
                    break;
            }
        }
    }
}

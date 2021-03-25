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
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for OfferListWindow.xaml
    /// </summary>
    public partial class OfferListWindow : Window
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;
        private readonly Guid _id;
        private readonly Utils.OfferListMode _mode;

        public OfferListWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Utils.OfferListMode mode,
            Guid id)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();
            _id = id;
            _mode = mode;
            LoadOffers();
        }

        private void LoadOffers()
        {
            try
            {
                switch (_mode)
                {
                    case Utils.OfferListMode.Material:
                        Offers.ItemsSource = _serviceContext.OfferService.GetMaterialOffers(_id);
                        break;
                    case Utils.OfferListMode.Company:
                        Offers.ItemsSource = _serviceContext.OfferService.GetCompanyOffers(_id);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
                Close();
            }
        }

        private OfferDto GetSelectedOffer()
        {
            return Offers.SelectedValue as OfferDto;
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            LoadOffers();
        }

        private void OnShowMaterials(object sender, RoutedEventArgs e)
        {
            var offer = GetSelectedOffer();
            if (offer != null)
            {
                new MaterialWindow(_serviceContext, _validatorContext, offer.Material.Id).Show();
            }
        }

        private void OnShowCompany(object sender, RoutedEventArgs e)
        {
            var offer = GetSelectedOffer();
            if (offer != null)
            {
                new CompanyWindow(_serviceContext, _validatorContext, offer.Company.Id).Show();
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var offer = GetSelectedOffer();
            if (offer != null)
            {
                new OfferWindow(_serviceContext, _validatorContext, offer.Id).Show();
            }
        }

        private void OnRemove(object sender, EventArgs e)
        {
            var selected = GetSelectedOffer();
            if (selected == null) return;
            try
            {
                new ServiceTransactionProxy<OfferOperationDto, OfferDto>(_serviceContext.OfferService)
                    .Delete(selected.Id);
                LoadOffers();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private void OnOfferListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                OnRemove(sender, e);
            }
        }
    }
}

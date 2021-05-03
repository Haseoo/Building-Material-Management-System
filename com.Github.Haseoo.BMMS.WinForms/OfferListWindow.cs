using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;
using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class OfferListWindow : Form
    {
        private readonly ServiceContext _serviceContext;
        private readonly ValidatorContext _validatorContext;
        private readonly Utils.OfferListMode _mode;
        private readonly Guid _id;

        public OfferListWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Utils.OfferListMode mode,
            Guid id)
        {
            _serviceContext = serviceContext;
            _mode = mode;
            _id = id;
            _validatorContext = validatorContext;
            SessionManager.Instance.AcquireNewSession();
            InitializeComponent();
            RefreshOffers();
        }

        private void RefreshOffers(object sender = null, System.EventArgs e = null)
        {
            switch (_mode)
            {
                case Utils.OfferListMode.Company:
                    OfferList.SetObjects(_serviceContext.OfferService.GetCompanyOffers(_id));
                    break;

                case Utils.OfferListMode.Material:
                    OfferList.SetObjects(_serviceContext.OfferService.GetMaterialOffers(_id));
                    break;
            }
        }

        private void OnShowOffer(object sender, EventArgs e)
        {
            var selected = GetSelectedOffer();
            if (selected != null)
            {
                try
                {
                    new OfferWindow(_serviceContext, _validatorContext, selected.Id).Show();
                }
                catch (BusinessLogicException ex)
                {
                    Utils.ShowErrorMessage(ex);
                }
            }
        }

        private OfferDto GetSelectedOffer()
        {
            return OfferList.SelectedObject as OfferDto;
        }

        private void OnRemoveBtnClick(object sender, EventArgs e)
        {
            var selected = GetSelectedOffer();
            if (selected != null)
            {
                try
                {
                    new TransactionalService<OfferOperationDto, OfferDto>(_serviceContext.OfferService)
                        .Delete(selected.Id);
                    RefreshOffers();
                }
                catch (Exception ex)
                {
                    Utils.ShowErrorMessage(ex);
                }
            }
        }

        private void OnShowMaterialBtnClick(object sender, EventArgs e)
        {
            var selected = GetSelectedOffer();
            if (selected != null)
            {
                try
                {
                    new MaterialWindow(_serviceContext, _validatorContext, selected.Material.Id).Show();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void OnCompanyBtnClick(object sender, EventArgs e)
        {
            var selected = GetSelectedOffer();
            if (selected != null)
            {
                try
                {
                    new CompanyWindow(_serviceContext, _validatorContext, selected.Company.Id).Show();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
}
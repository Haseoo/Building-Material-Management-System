using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Services.Adapters;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;
using System;
using System.Windows;
using System.Windows.Input;

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
            OrderLists.ItemsSource = serviceContext.OrderListService.GetList();
        }

        private void OnCompanyAdd(object sender, RoutedEventArgs e)
        {
            new CompanyWindow(_serviceContext, _validatorContext).Show();
        }

        private void OnMaterialAdd(object sender, RoutedEventArgs e)
        {
            new MaterialWindow(_serviceContext, _validatorContext).Show();
        }

        private void OnOfferAdd(object sender, RoutedEventArgs e)
        {
            new OfferWindow(_serviceContext, _validatorContext).Show();
        }

        private void OnAddOrderList(object sender, RoutedEventArgs e)
        {
            var dialog = new TextInputDialog("Enter list name", "New order list");
            if (!(dialog.ShowDialog() ?? false))
            {
                return;
            }
            var name = dialog.GetUserInput();
            if (string.IsNullOrEmpty(name))
            {
                Utils.ShowErrorMessage("List name cannot be empty");
                return;
            }

            try
            {
                new ServiceTransactionProxy<string, OrderListFullDto>(_serviceContext.OrderListService)
                    .Add(name);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
            OnOrderListSearchOrRefresh(sender, e);
        }

        private void OnPdfSave(object sender, RoutedEventArgs e)
        {
        }

        private void OnMaterialSearchOrRefresh(object sender = null, RoutedEventArgs e = null)
        {
            var materialName = MaterialInput.Text;
            try
            {
                Materials.ItemsSource = string.IsNullOrEmpty(materialName) ?
                    _serviceContext.MaterialService.GetList() :
                    _serviceContext.MaterialService.SearchByName(materialName);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private void OnCompanySearchOrRefresh(object sender = null, RoutedEventArgs e = null)
        {
            var companyName = CompanyInput.Text;
            try
            {
                Companies.ItemsSource = string.IsNullOrEmpty(companyName) ?
                    _serviceContext.CompanyService.GetList() :
                    _serviceContext.CompanyService.SearchByName(companyName);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private void OnOrderListSearchOrRefresh(object sender = null, RoutedEventArgs e = null)
        {
            var orderListInput = OrderListsInput.Text;
            try
            {
                OrderLists.ItemsSource = string.IsNullOrEmpty(orderListInput) ?
                    _serviceContext.OrderListService.GetList() :
                    _serviceContext.OrderListService.SearchByName(orderListInput);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private void OnEntryEdit(object sender, RoutedEventArgs e)
        {
            TabAction(() =>
            {
                var selected = GetSelectedCompany();
                if (selected != null)
                {
                    new CompanyWindow(_serviceContext, _validatorContext, selected.Id).Show();
                }
            }, () =>
            {
                var selected = GetSelectedMaterial();
                if (selected != null)
                {
                    new MaterialWindow(_serviceContext, _validatorContext, selected.Id).Show();
                }
            }, () =>
            {
                var selected = GetSelectedOrderList();
                if (selected != null)
                {
                    new OrderListWindow(_serviceContext, _validatorContext, selected.Id).Show();
                }
            });
        }

        private void DeleteCompany()
        {
            var selected = GetSelectedCompany();
            if (selected != null)
            {
                new ServiceTransactionProxy<CompanyOperationDto, CompanyDto>(_serviceContext.CompanyService)
                    .Delete(selected.Id);
                OnCompanySearchOrRefresh();
            }
        }

        private void DeleteMaterial()
        {
            var selected = GetSelectedMaterial();
            if (selected != null)
            {
                new ServiceTransactionProxy<MaterialOperationDto, MaterialDto>(_serviceContext.MaterialService)
                    .Delete(selected.Id);
                OnMaterialSearchOrRefresh();
            }
        }

        private void DeleteOrderList()
        {
            var selected = GetSelectedOrderList();
            if (selected != null)
            {
                new ServiceTransactionProxy<string, OrderListFullDto>(_serviceContext.OrderListService)
                    .Delete(selected.Id);
                OnOrderListSearchOrRefresh();
            }
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                TabAction(DeleteCompany, DeleteMaterial, DeleteOrderList);
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
        }

        private MaterialDto GetSelectedMaterial()
        {
            return Materials.SelectedValue as MaterialDto;
        }

        private CompanyDto GetSelectedCompany()
        {
            return Companies.SelectedValue as CompanyDto;
        }

        private OrderListShortDto GetSelectedOrderList()
        {
            return OrderLists.SelectedValue as OrderListShortDto;
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            TabAction(() =>
            {
                OnCompanySearchOrRefresh(sender, e);
            }, () =>
            {
                OnMaterialSearchOrRefresh(sender, e);
            }, () =>
            {
                OnCompanySearchOrRefresh(sender, e);
            });
        }

        private void TabAction(Action onCompanySelected, Action onMaterialSelected, Action onOrderListSelected)
        {
            if (CompaniesTab.IsSelected)
            {
                onCompanySelected.Invoke();
            }
            else if (MaterialsTab.IsSelected)
            {
                onMaterialSelected.Invoke();
            }
            else if (OrderListsTab.IsSelected)
            {
                onOrderListSelected.Invoke();
            }
        }

        private void OnDataGridRowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                OnDelete(sender, e);
            }
        }

        private void OnClose(object sender = null, RoutedEventArgs e = null)
        {
            SessionManager.Instance.Dispose();
            Close();
        }

        private void OnSearchEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TabAction(() => OnCompanySearchOrRefresh(sender, e),
                    () => OnMaterialSearchOrRefresh(sender, e),
                    () => OnOrderListSearchOrRefresh(sender, e));
            }
        }
    }
}
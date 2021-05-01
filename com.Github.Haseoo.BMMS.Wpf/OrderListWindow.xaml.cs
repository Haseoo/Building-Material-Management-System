using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        private readonly IOrderListService _orderListService;
        private OrderListFullDto _currentList;
        private ValidatorContext _validatorContext;

        public OrderListWindow(IOrderListService orderListService,
            ValidatorContext validatorContext,
            Guid id)
        {
            _orderListService = orderListService;
            _validatorContext = validatorContext;
            InitializeComponent();
            DisplayOrderList(id);
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {

        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnDataGridKeyPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                OnEntryDelete(sender, e);
            }
        }

        private void OnEntryEdit(object sender, RoutedEventArgs routedEventArgs)
        {
            throw new System.NotImplementedException();
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            DisplayOrderList(_currentList.Id);
        }

        private void OnShowEntry(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnEntryDelete(object sender, RoutedEventArgs e)
        {
            if (!(Positions.SelectedItem is OrderPositionDto selected))
            {
                return;
            }
            Positions.Items.Remove(selected);
        }

        private void DisplayOrderList(Guid id)
        {
            try
            {
                SessionManager.Instance.AcquireNewSession();
                _currentList = _orderListService.GetById(id);
                ListName.Text = _currentList.Name;
                Positions.ItemsSource = _currentList.OrderPositions;
                TotalValue.Content = _currentList.OrderPositions
                    .Select(e => e.Quantity * e.Offer.UnitPrice)
                    .Sum();
                TotalValue.Content += " " + NumberFormatInfo.CurrentInfo.CurrencySymbol;
            }
            catch (Exception e)
            {
                Utils.ShowErrorMessage(e);
                Close();
            }
        }
    }
}
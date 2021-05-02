using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;
using NHibernate.Linq;
using Remotion.Linq.Collections;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        private readonly ServiceContext _serviceContext;
        private OrderListFullDto _currentList;

        private readonly ObservableCollection<OrderPositionDto> _positionDtos =
            new ObservableCollection<OrderPositionDto>();

        private readonly ValidatorContext _validatorContext;

        public OrderListWindow(ServiceContext serviceContext,
            ValidatorContext validatorContext,
            Guid id)
        {
            _serviceContext = serviceContext;
            _validatorContext = validatorContext;
            InitializeComponent();
            Positions.ItemsSource = _positionDtos;
            DisplayOrderList(id);
            ListName.Text = _currentList.Name;
            Title = _currentList.Name;
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            var dtoBuilder = OrderListUpdateDto.Builder();
            dtoBuilder.Name(ListName.Text);
            foreach (var orderPositionDto in _positionDtos)
            {
                var positionDtoBuilder = OrderListPositionOperationDto.Builder();
                positionDtoBuilder.Quantity(orderPositionDto.Quantity);
                positionDtoBuilder.OfferId(orderPositionDto.Offer.Id);
                positionDtoBuilder.OrderListId(_currentList.Id);
                dtoBuilder.OrderPosition(positionDtoBuilder.Build());
            }

            var operation = dtoBuilder.Build();

            if (Utils.ShowInputErrorMessage(_validatorContext.OrderListEditDtoValidator.Validate(operation)))
            {
                return;
            }

            try
            {
                _serviceContext.OrderListService.Update(_currentList.Id, operation);
                SessionManager.Instance.AcquireNewSession();
                Close();
            }
            catch (Exception ex)
            {
                Utils.ShowErrorMessage(ex);
            }
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
            if (!(Positions.SelectedItem is OrderPositionDto selected))
            {
                return;
            }
            var dialog = new AddElementToOrderListDialog(_currentList, selected, _validatorContext);
            if (!(dialog.ShowDialog() ?? false))
            {
                return;
            }

            var selectedIndex = Positions.SelectedIndex;
            _positionDtos.Insert(selectedIndex, OrderPositionDto.WithNewQuantity(selected,
                dialog.GetUserInput().Quantity));
            _positionDtos.Remove(selected);
            DisplayTotalValue();
            Positions.Items.Refresh();
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            DisplayOrderList(_currentList.Id);
        }

        private void OnShowOffer(object sender, RoutedEventArgs e)
        {
            if (Positions.SelectedItem is OrderPositionDto selected)
            {
                new OfferWindow(_serviceContext, _validatorContext, selected.Offer.Id).Show();
            }
        }

        private void OnEntryDelete(object sender, RoutedEventArgs e)
        {
            if (!(Positions.SelectedItem is OrderPositionDto selected))
            {
                return;
            }
            _positionDtos.Remove(selected);
            DisplayTotalValue();
            Positions.Items.Refresh();
        }

        private void DisplayOrderList(Guid id)
        {
            try
            {
                SessionManager.Instance.AcquireNewSession();
                _currentList = _serviceContext.OrderListService.GetById(id);
                ListName.Text = _currentList.Name;
                _currentList.OrderPositions.ForEach(_positionDtos.Add);
                DisplayTotalValue();
            }
            catch (Exception e)
            {
                Utils.ShowErrorMessage(e);
                Close();
            }
        }

        private void DisplayTotalValue()
        {
            TotalValue.Content = _positionDtos
                .Select(e => e.Quantity * e.Offer.UnitPrice)
                .Sum();
            TotalValue.Content += " " + NumberFormatInfo.CurrentInfo.CurrencySymbol;
        }
    }
}
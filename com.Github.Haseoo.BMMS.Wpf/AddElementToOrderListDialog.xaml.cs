using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Validators;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for AddElementToOrderListDialog.xaml
    /// </summary>
    public partial class AddElementToOrderListDialog : Window
    {
        private readonly Guid _offerId;
        private readonly ValidatorContext _validatorContext;

        public AddElementToOrderListDialog(IEnumerable<OrderListShortDto> orderLists,
            Guid offerId,
            ValidatorContext validatorContext)
        {
            InitializeComponent();
            OrderListSelector.ItemsSource = orderLists;
            _offerId = offerId;
            _validatorContext = validatorContext;
            
        }

        private void OnQuantityChanged(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utils.NumberRegex.IsMatch(e.Text);
        }

        public OrderListPositionOperationDto GetUserInput()
        {
            var builder = OrderListPositionOperationDto.Builder();
            if (int.TryParse(Quantity.Text, out var qty))
            {
                builder.Quantity(qty);
            }

            if ((OrderListSelector.SelectedItem is OrderListShortDto selected))
            {
                builder.OrderListId(selected.Id);
            }

            return builder
                .OfferId(_offerId)
                .Build();
        }

        private void OnOk(object sender, RoutedEventArgs e)
        {
            if(Utils.ShowInputErrorMessage(_validatorContext
                .OrderListPositionAddDtoValidator
                .Validate(GetUserInput())))
            {
                return;
            }
            DialogResult = true;
        }
    }
}
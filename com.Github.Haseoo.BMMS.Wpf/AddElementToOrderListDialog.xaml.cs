using System.Windows;
using System.Windows.Input;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for AddElementToOrderListDialog.xaml
    /// </summary>
    public partial class AddElementToOrderListDialog : Window
    {
        public AddElementToOrderListDialog()
        {
            InitializeComponent();
        }

        private void OnQuantityChanged(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utils.NumberRegex.IsMatch(e.Text);
        }

        private void OnOk(object sender, RoutedEventArgs e)
        {
        }
    }
}
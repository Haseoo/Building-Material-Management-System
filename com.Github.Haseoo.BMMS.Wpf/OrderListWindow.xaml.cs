using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        public OrderListWindow()
        {
            InitializeComponent();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {

        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
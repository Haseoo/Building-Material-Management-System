using System.Windows;
using System.Windows.Input;

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

        private void OnDataGridKeyPreviewKeyDown(object sender, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnEntryEdit(object sender, RoutedEventArgs routedEventArgs)
        {
            throw new System.NotImplementedException();
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnShowEntry(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnEntryDelete(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
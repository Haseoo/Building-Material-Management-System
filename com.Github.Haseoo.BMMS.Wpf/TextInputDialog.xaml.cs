using System;
using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for TextInputDialog.xaml
    /// </summary>
    public partial class TextInputDialog : Window
    {
        public TextInputDialog(string content, string title = null, string defaultValue = "")
        {
            InitializeComponent();
            ContentText.Content = content;
            Value.Text = defaultValue;
            this.Title = title ?? "Text input";
        }

        public string GetUserInput()
        {
            return Value.Text;
        }

        private void OnOk(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void OnWindowRendered(object sender, EventArgs e)
        {
            Value.SelectAll();
            Value.Focus();
        }
    }
}
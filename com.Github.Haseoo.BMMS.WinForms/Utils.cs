using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public static class Utils
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

         public static void ShowErrorMessage(Exception exception)
         {
            ShowErrorMessage(exception.Message);
         }
    }
}


using FluentNHibernate.Cfg;
using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainWindow());
            }
            catch (FluentConfigurationException e)
            {
                MessageBox.Show(e.GetBaseException().Message, "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

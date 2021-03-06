﻿using FluentNHibernate.Cfg;
using System;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
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
﻿using FluentValidation.Results;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public static class Utils
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

         public static void ShowErrorMessage(Exception exception)
         {
            ShowErrorMessage(exception.Message);
         }

        public static bool ShowInputErrorMessage(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return false;
            }
            var message = validationResult.Errors.Select(err => err.ErrorMessage).Aggregate((c, n) => c + ", " + n);
            MessageBox.Show(message, "Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return true;
        }

        public enum OfferListMode
        {
            Company,
            Material
        }
    }
}

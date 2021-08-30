using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;

namespace TRMDekstopUI.Helpers
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject passwordObject)
        {
            var box = passwordObject as PasswordBox;
            if (box != null)
            {
                // this funny little dance here ensures that we've hooked the
                // PasswordChanged event once, and only once.
                box.PasswordChanged -= PasswordChanged;
                box.PasswordChanged += PasswordChanged;
            }

            return (string)passwordObject.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject passwordObject, string value)
        {
            if (string.Equals(value, GetBoundPassword(passwordObject)))
            {
                return; // and this is how we prevent infinite recursion
            }

            passwordObject.SetValue(BoundPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged(
            DependencyObject passwordObject,
            DependencyPropertyChangedEventArgs events)
        {
            var box = passwordObject as PasswordBox;

            if (box == null)
            {
                return;
            }

            box.Password = GetBoundPassword(passwordObject);
        }

        private static void PasswordChanged(object sender, RoutedEventArgs events)
        {
            PasswordBox password = sender as PasswordBox;

            SetBoundPassword(password, password.Password);

            // set cursor past the last character in the password box
            password.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(password, new object[] { password.Password.Length, 0 });
        }

    }
}
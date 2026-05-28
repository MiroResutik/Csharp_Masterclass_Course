using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login
{
    public partial class MainWindow : Window
    {
        // Saved credentials
        private const string SavedUsername = "admin";
        private const string SavedPassword = "1234";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputChanged(object sender, RoutedEventArgs e)
        {
            // Enable button only if both fields contain text
            LoginButton.IsEnabled =
                !string.IsNullOrWhiteSpace(UsernameBox.Text) &&
                !string.IsNullOrWhiteSpace(PasswordBox.Password);
        }
        // Handle login button click
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            // Validate credentials
            if (username == SavedUsername && password == SavedPassword)
            {
                SecondWindow secondWindow = new SecondWindow(username, password);
                secondWindow.Show();

                this.Close();
                
            }
            else
            {
                // Show specific error messages
                if (username != SavedUsername && password != SavedPassword)
                {
                    MessageBox.Show(
                        "Both username and password are incorrect!",
                        "Login Failed",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else if (username != SavedUsername)
                {
                    MessageBox.Show(
                        "Username is incorrect!",
                        "Login Failed",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else if (password != SavedPassword)
                {
                    MessageBox.Show(
                        "Password is incorrect!",
                        "Login Failed",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                
            }

            
        }
    }
}

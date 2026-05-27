// SecondWindow.xaml.cs
using System.Windows;

namespace Login
{
    public partial class SecondWindow : Window
    {
        public SecondWindow(string username, string password)
        {
            InitializeComponent();

            UsernameText.Text = username;
            PasswordText.Text = password;
        }
    }
}
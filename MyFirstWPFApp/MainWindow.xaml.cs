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

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Constructor for the MainWindow class
        public MainWindow()
        {
            InitializeComponent();

            // Button creation and addition to the grid using code-behind
            /*
            // Create a new Button control instance
            Button myButton = new Button();
            myButton.Content = "Click Me!";

            Grid.SetRow(myButton, 3); // Set the row for the button
            Grid.SetColumn(myButton, 4); // Set the column for the button

            Grid myGrid = (Grid)FindName("myGrid");
            myGrid.Children.Add(myButton); // Add the button to the grid
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked!");
        }

    }
}

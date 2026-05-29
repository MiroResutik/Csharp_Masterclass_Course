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
using System.Configuration;
using System.Data.SqlClient;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare the SqlConnection object at the class level
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();


            // Retrieve the connection string from the configuration file
            string connectionString = ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.MiroDBConnectionString"].ConnectionString;
            // Initialize the SqlConnection object with the retrieved connection string
            sqlConnection = new SqlConnection(connectionString);




        }

        private void ShowZoos()
        {
            string query = "SELECT * FROM Zoos";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
        }
    }
}

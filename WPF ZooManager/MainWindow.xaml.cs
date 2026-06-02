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
using System.Data;

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

            //ShowAssociatedAnimals();
            ShowZoos();
            ShowAllAnimals();

        }

        public void ShowZoos()
        {
            try
            {
                string query = "SELECT * FROM Zoo";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    // The DataTable can be imagined as a Table in C#-Objects
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);
                    // Which info of the table in DataTAble should be shown in our listbox
                    listZoos.DisplayMemberPath = "Location";
                    
                    // Which Value should be delivered, when an item from our listbox is selected
                    listZoos.SelectedValuePath = "Id";
                    
                    // Refernce to the data the listbox shoild polulate
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

        }

        private void ShowAllAnimals()
        {
            try
            {
                string query = "SELECT * FROM Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    // The DataTable can be imagined as a Table in C#-Objects
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);
                    // Which info of the table in DataTAble should be shown in our listbox
                    listAllAnimals.DisplayMemberPath = "Name";
                    // Which Value should be delivered, when an item from our listbox is selected
                    listAllAnimals.SelectedValuePath = "Id";
                    // Refernce to the data the listbox shoild polulate
                    listAllAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowAssociatedAnimals()
        {

            //MessageBox.Show("ShowAssociatedAnimals");
            
            try
            {
                string query = "select * from Animal a inner join ZooAnimal " +
                    "za on a.Id = za.AnimalId where za.ZooId = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // the SqlDataAdapter can be imagined like an Interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter) 
                {
                    // We have to add the parameter @ZooId, because we used it in our query
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    //Which Information of the Table in DataTable should be shown in our ListBox?
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    //Which Value should be delivered, when an Item from our ListBox is selected?
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    //The Reference to the Data the ListBox should populate
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
            
        }
        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(listZoos.SelectedValue.ToString());
            ShowAssociatedAnimals();
            //ShowAllAnimals();
            ShowSelectedZooInTextBox();
            
            

        }

        private void btnDeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Zoo WHERE Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @ZooId, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes
                

                ShowZoos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void btnAddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @Location, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes
                

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "select location from Zoo where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // the SqlDataAdapter can be imagined like an Interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    // We have to add the parameter @ZooId, because we used it in our query
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zooDataTable = new DataTable();

                    sqlDataAdapter.Fill(zooDataTable);

                    myTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "select name from Animal where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // the SqlDataAdapter can be imagined like an Interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    // We have to add the parameter @ZooId, because we used it in our query
                    sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                    DataTable animalDataTable = new DataTable();

                    sqlDataAdapter.Fill(animalDataTable);

                    myTextBox.Text = animalDataTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void btnUpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Zoo Set Location =  @location where Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @Location, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void btnRemoveAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "select location from Zoo where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // the SqlDataAdapter can be imagined like an Interface to make Tables usable by C#-Objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zooDataTable = new DataTable();

                    sqlDataAdapter.Fill(zooDataTable);

                    myTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
       
        private void btnUpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Animal Set Name =  @name where Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @Location, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();     

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void btnDeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Animal WHERE Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @AnimalId, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes


                ShowZoos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @Location, because we used it in our query
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void btnAddAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                // Open the connection to the database, because we want to execute a command
                sqlConnection.Open();
                // We have to add the parameter @ZooId, because we used it in our query as well as @AnimalId
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                // ExecuteScalar is used, when we want to get a single value from the database, for example the Id of a newly created record
                sqlCommand.ExecuteScalar();
                // After deleting the Zoo, we have to update our ListBox to show the changes



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // After deleting the Zoo, we have to update our ListBox to show the changes
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void listAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }
    }
}

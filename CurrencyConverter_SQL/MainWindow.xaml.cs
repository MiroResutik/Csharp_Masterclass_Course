using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CurrencyConverter_SQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaring global variables for database connection and operations, as well as variables to hold currency conversion data.
        SqlConnection con = new SqlConnection(); // Creating Object of SqlConnection class to establish a connection to the database.
        SqlCommand cmd = new SqlCommand(); // Creating Object of SqlCommand class to execute SQL commands against the database.
        SqlDataAdapter da = new SqlDataAdapter(); // Creating Object of SqlDataAdapter class to fill a DataSet and update the database.

        // Variables to hold the ID of the currency and the amounts for conversion, which are likely used for database operations and currency conversion calculations.
        private int CurrencyId = 0; // Variable to hold the ID of the currency, likely used for database operations.
        private double FromAmount = 0; // Variable to hold the amount of currency to convert from.
        private double ToAmount = 0; // Variable to hold the amount of currency after conversion.

        //CRUD Operations for Currency
        // The MainWindow constructor is responsible for initializing the components of the main window, binding the currency data to the ComboBoxes, and retrieving existing currency records to display in the DataGrid when the application starts.
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency(); 
            BindCurrency(); // Calling the BindCurrency method to populate the ComboBoxes with currency data when the main window is initialized.
            GetData(); // Calling the GetData method to retrieve and display the existing currency records in the DataGrid when the main window is initialized.

        }
        public void mycon()
        {
            // Retrieving the connection string from the application's configuration file.
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            // Initializing the SqlConnection object with the retrieved connection string.
            con = new SqlConnection(Conn);
            // Opening the connection to the database.
            con.Open();

        }
        // The BindCurrency method is responsible for retrieving currency data from the database and binding it to the ComboBoxes in the user interface, allowing users to select currencies for conversion.
        private void BindCurrency()
        {
            // This method is responsible for binding currency data to the ComboBoxes in the user interface.
            mycon();
            // Creating a DataTable to hold the currency data retrieved from the database.
            DataTable dt = new DataTable();
            // Executing a SQL command to select the Id and CurrencyName from the Currency_master table in the database.
            cmd = new SqlCommand("select Id, CurrencyName from Currency_master", con);
            // Setting the command type to Text, indicating that the command is a SQL query.
            cmd.CommandType = CommandType.Text;
            // Initializing the SqlDataAdapter with the SqlCommand to fill the DataTable.
            da = new SqlDataAdapter(cmd);
            // Filling the DataTable with the results of the SQL query.
            da.Fill(dt); 
            // Creating a new Object for DataRow to represent the default selection in the ComboBox.
            DataRow newRow = dt.NewRow(); 

            newRow["Id"] = 0; // Setting the Id of the default selection to 0.
            newRow["CurrencyName"] = "--SELECT--"; // Setting the display text for the default selection.


            dt.Rows.InsertAt(newRow, 0); // Inserting the default selection at the top of the DataTable.

            if (dt != null && dt.Rows.Count > 0)
            {
                // Binding the DataTable to the ComboBox for the source currency. The DisplayMemberPath specifies which column to display, and the SelectedValuePath specifies which column to use as the value.
                cmbFromCurrency.ItemsSource = dt.DefaultView;
                //cmbFromCurrency.DisplayMemberPath = "CurrencyName";
                //cmbFromCurrency.SelectedValuePath = "Id";
                // Setting the default selection to the first item in the ComboBox.
                //cmbFromCurrency.SelectedIndex = 0; 
                // Similarly binding the same DataTable to another ComboBox for the target currency.
                cmbToCurrency.ItemsSource = dt.DefaultView;
                //cmbToCurrency.DisplayMemberPath = "CurrencyName";
                //cmbToCurrency.SelectedValuePath = "Id";
                // Setting the default selection to the first item in the ComboBox.
                //cmbToCurrency.SelectedIndex = 0; 
            }
            // Closing the connection to the database after the data has been retrieved and bound to the ComboBoxes.
            con.Close();

            // Static data for currency conversion rates. In a real application, this data would likely come from a database or an API, but here it's hardcoded for demonstration purposes.
            /*
            // This method is intended to bind currency data to a ComboBox or similar control.
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");
            

            // Adding currency data to the DataTable. In a real application, this data might come from a database or an API.
            dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("USD", 1.0);
            dtCurrency.Rows.Add("EUR", 0.85);
            dtCurrency.Rows.Add("GBP", 0.75);
            dtCurrency.Rows.Add("JPY", 110.0);
            dtCurrency.Rows.Add("AUD", 1.3);
            dtCurrency.Rows.Add("CAD", 1.25);
            dtCurrency.Rows.Add("CHF", 0.92);
            dtCurrency.Rows.Add("CNY", 6.5);
            dtCurrency.Rows.Add("SEK", 8.5);
            dtCurrency.Rows.Add("NZD", 1.4);
            dtCurrency.Rows.Add("MXN", 20.0);
            dtCurrency.Rows.Add("SGD", 1.35);
            dtCurrency.Rows.Add("HKD", 7.8);
            dtCurrency.Rows.Add("NOK", 8.8);
            dtCurrency.Rows.Add("KRW", 1100.0);
            */

            // Binding the DataTable to the ComboBox. The DisplayMemberPath specifies which column to display, and the SelectedValuePath specifies which column to use as the value.
            //cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";
            cmbFromCurrency.SelectedValuePath = "Id";
            cmbFromCurrency.SelectedIndex = 0;
            // Similarly binding the same DataTable to another ComboBox for the target currency.
            //cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Id";
            cmbToCurrency.SelectedIndex = 0;


        }
        // The Convert_Click method is responsible for handling the click event of the Convert button. It validates the user input, performs the currency conversion calculation based on the selected source and target currencies, and displays the converted value in the user interface.
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            lblCurrency.Content = "Please Enter Currency Amount!!!";

            double ConvertedValue;
            // Validating the input for currency amount. If it's empty, show a message box and set focus back to the input field.
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                // If the input for currency amount is empty, show a message box and set focus back to the input field.
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedValue.ToString() == "0")
            {
                // If the source currency is not selected, show a message box and set focus back to the ComboBox.
                MessageBox.Show("Please Select From Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbFromCurrency.Focus();
                return;
            }
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedValue.ToString() == "0")
            {
                // If the target currency is not selected, show a message box and set focus back to the ComboBox.
                MessageBox.Show("Please Select To Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbToCurrency.Focus();
                return;
            }
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                try
                {
                    ConvertedValue = double.Parse(txtCurrency.Text);
                    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                }
                catch (System.Exception)
                {

                    MessageBox.Show(
                    "Please enter a valid number!",
                    "Invalid Input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                    txtCurrency.Clear();
                    txtCurrency.Focus();
                }

            }
            else
            {
                // Performing the currency conversion calculation based on the selected source and target currencies.
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");

            }
        }
        // The ClearControls method is responsible for clearing the input fields and resetting the ComboBoxes to their default state, allowing the user to start a new currency conversion without any previous data.
        private void ClearControls()
        {
            // This method is intended to clear the input fields and reset the ComboBoxes to their default state.
            txtCurrency.Text = string.Empty; // Clear the text input for currency amount.
            cmbFromCurrency.SelectedIndex = 0; // Reset the source currency ComboBox to the default selection.
            cmbToCurrency.SelectedIndex = 0; // Reset the target currency ComboBox to the default selection.
            lblCurrency.Content = string.Empty; // Clear the label that displays the converted currency result.
        }
        // The Clear_Click method is an event handler for the Clear button's click event. It calls the ClearControls method to reset the form and clear any user input, allowing the user to start fresh with a new currency conversion.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }
        // The NumberValidationTextBox method is an event handler for the TextComposition event of the currency amount input field. It uses a regular expression to allow only numeric input (including decimal points and commas) and prevents any non-numeric characters from being entered into the input field.
        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+"); // Regular expression to allow only numeric input.
            e.Handled = regex.IsMatch(e.Text); // If the input does not match the regex (i.e., it's not a number), mark the event as handled to prevent the input.

        }
        // The btnSave_Click method is responsible for handling the click event of the Save button. It validates the user input for currency amount and name, determines whether to perform an insert or update operation based on the CurrencyId, and interacts with the database to save or update the currency record accordingly.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amount", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    if (CurrencyId > 0)
                    {
                        // If CurrencyID is greater than 0, it indicates that we are updating an existing currency record. A confirmation message box is shown to the user before proceeding with the update.
                        if (MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            // Code to update the existing currency record in the database would go here.
                            mycon();
                            // Creating a object of DataTable to hold the data that will be updated in the database. This is typically used to execute the SQL command and manage the data.
                            DataTable dt = new DataTable();
                            // The SQL command to update the currency record in the database is prepared. It updates the CurrencyName and Amount fields for the record with the specified Id.
                            cmd = new SqlCommand("UPDATE Currency_Master SET CurrencyName=@CurrencyName, Amount=@Amount WHERE Id=@Id", con);

                            cmd.CommandType = CommandType.Text; // The parameters for the SQL command are added, including the CurrencyName, Amount, and Id.
                            cmd.Parameters.AddWithValue("@Id", CurrencyId); // Adding the CurrencyID as a parameter to identify which record to update.
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text); // Adding the new currency name as a parameter.
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text); // Adding the new amount as a parameter.
                            cmd.ExecuteNonQuery(); // Executing the SQL command to update the record in the database.
                            con.Close();

                            MessageBox.Show("Record updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information); // Informing the user that the record has been updated successfully.
                        }
                    }
                    else // Save button is clicked and CurrencyID is 0, it indicates that we are adding a new currency record. A confirmation message box is shown to the user before proceeding with the save operation.

                    {
                        if (MessageBox.Show("Are you sure you want to Save ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                    }
                    ClearMaster(); // After saving or updating the record, the ClearMaster method is called to reset the form and refresh the data displayed in the user interface.

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error saving file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // The btnCancel_Click method is responsible for handling the click event of the Cancel button. It calls the ClearMaster method to reset the form and clear any user input, allowing the user to start fresh without saving any changes.
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearMaster();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while clearing the form", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        // The txtAmount_TextChanged and txtCurrencyName_TextChanged methods are event handlers for the TextChanged event of the Amount and CurrencyName input fields, respectively. Currently, they do not contain any logic, but they can be used to implement real-time validation or other functionality as needed when the text in these fields changes.
        private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txtCurrencyName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //DataGrid selected cell changed event
        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                //Create object for DataGrid
                DataGrid grd = (DataGrid)sender;
                //Create object for DataRowView
                DataRowView row_selected = grd.CurrentItem as DataRowView;

                //row_selected is not null
                if (row_selected != null)
                {

                    //dgvCurrency items count greater than zero
                    if (dgvCurrency.Items.Count > 0)
                    {
                        if (grd.SelectedCells.Count > 0)
                        {

                            //Get selected row Id column value and Set in CurrencyId variable
                            CurrencyId = Int32.Parse(row_selected["Id"].ToString());

                            //DisplayIndex is equal to zero than it is Edit cell
                            if (grd.SelectedCells[0].Column.DisplayIndex == 0)
                            {

                                //Get selected row Amount column value and Set in Amount textbox
                                txtAmount.Text = row_selected["Amount"].ToString();

                                //Get selected row CurrencyName column value and Set in CurrencyName textbox
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString();

                                //Change save button text Save to Update
                                btnSave.Content = "Update";
                            }

                            //DisplayIndex is equal to one than it is Delete cell                    
                            if (grd.SelectedCells[0].Column.DisplayIndex == 1)
                            {
                                //Show confirmation dialogue box
                                if (MessageBox.Show("Are you sure you want to delete ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    mycon();
                                    DataTable dt = new DataTable();

                                    //Execute delete query for delete record from table using Id
                                    cmd = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", con);
                                    cmd.CommandType = CommandType.Text;

                                    //CurrencyId set in @Id parameter and send it in delete statement
                                    cmd.Parameters.AddWithValue("@Id", CurrencyId);
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    MessageBox.Show("Data deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    ClearMaster();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //From currency combobox selection changed event for get amount of currency on selection change of currency name
        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Check condition cmbFromCurrency.SelectedValue not is equal to null and not equal to zero
                if (cmbFromCurrency.SelectedValue != null && int.Parse(cmbFromCurrency.SelectedValue.ToString()) != 0 && cmbFromCurrency.SelectedIndex != 0)
                {
                    //cmbFromCurrency.SelectedValue set in CurrencyFromId variable
                    int CurrencyFromId = int.Parse(cmbFromCurrency.SelectedValue.ToString());

                    mycon();
                    DataTable dt = new DataTable();

                    //Select query for get Amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyFromId", con);
                    cmd.CommandType = CommandType.Text;

                    //CurrencyFromId set in @CurrencyFromId parameter and send parameter in our query
                    if (CurrencyFromId != null && CurrencyFromId != 0)
                    {
                        cmd.Parameters.AddWithValue("@CurrencyFromId", CurrencyFromId);
                    }
                    da = new SqlDataAdapter(cmd);

                    //Set the data that the query returns in the data table
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //Get amount column value from datatable and set amount value in FromAmount variable which is declared globally
                        FromAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //cmbFromCurrency preview key down event
        private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If the user press Tab or Enter key then cmbFromCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbFromCurrency_SelectionChanged(sender, null);
            }
        }
        //cmbToCurrency preview key down event
        private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If the user press Tab or Enter key then cmbToCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbToCurrency_SelectionChanged(sender, null);
            }
        }
        //To currency combobox selection changed event for get amount of currency on selection change of currency name
        private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Check condition cmbToCurrency SelectedValue not is equal to null and not equal to zero
                if (cmbToCurrency.SelectedValue != null && int.Parse(cmbToCurrency.SelectedValue.ToString()) != 0 && cmbToCurrency.SelectedIndex != 0)
                {
                    //cmbToCurrency SelectedValue set in CurrencyToId variable
                    int CurrencyToId = int.Parse(cmbToCurrency.SelectedValue.ToString());

                    mycon();
                    DataTable dt = new DataTable();

                    //Select query for get Amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyToId", con);
                    cmd.CommandType = CommandType.Text;

                    //CurrencyToId set in @CurrencyToId parameter and send parameter in our query
                    if (CurrencyToId != null && CurrencyToId != 0)
                    {
                        cmd.Parameters.AddWithValue("@CurrencyToId", CurrencyToId);
                    }

                    da = new SqlDataAdapter(cmd);
                    //Set the data that the query returns in the data table
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //Get amount column value from datatable and set amount value in ToAmount variable which is declared globally            
                        ToAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Bind Data in DataGrid View.
        public void GetData()
        {
            //The method is used for connect with database and open database connection    
            mycon();

            //Create Datatable object
            DataTable dt = new DataTable();

            //Write Sql Query for Get data from database table. Query written in double quotes and after comma provide connection    
            cmd = new SqlCommand("SELECT * FROM Currency_Master", con);

            //CommandType define Which type of command execute like Text, StoredProcedure, TableDirect.    
            cmd.CommandType = CommandType.Text;

            //It is accept a parameter that contains the command text of the object's SelectCommand property.
            da = new SqlDataAdapter(cmd);

            //The DataAdapter serves as a bridge between a DataSet and a data source for retrieving and saving data. The Fill operation then adds the rows to destination DataTable objects in the DataSet    
            da.Fill(dt);

            //dt is not null and rows count greater than 0
            if (dt != null && dt.Rows.Count > 0)
            {
                //Assign DataTable data to dgvCurrency using ItemSource property.   
                dgvCurrency.ItemsSource = dt.DefaultView;
            }
            else
            {
                dgvCurrency.ItemsSource = null;
            }
            //Database connection Close
            con.Close();
        }
        // The ClearMaster method is responsible for clearing the input fields, resetting the form to its default state, and refreshing the data displayed in the user interface after a save or update operation.
        private void ClearMaster()
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "Save";
                GetData();
                CurrencyId = 0;
                BindCurrency();
                txtAmount.Focus();

            }
            catch (Exception)
            {

                MessageBox.Show("Error while clearing the form", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}

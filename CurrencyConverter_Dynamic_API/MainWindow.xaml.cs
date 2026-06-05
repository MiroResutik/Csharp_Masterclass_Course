using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CurrencyConverter_Dynamic_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This variable is intended to hold the exchange rate data retrieved from the API. It is an instance of the 'Root' class, which is designed to match the structure of the JSON response from the currency exchange rates API. The 'val' variable will be populated with the exchange rates and other relevant data when the application retrieves data from the API.
        Root val = new Root(); 

        // The 'Root' class is intended to represent the structure of the JSON response from a currency exchange rates API. It contains a property for the exchange rates (of type 'Rate'), a timestamp for when the rates were retrieved, and a license string that may indicate the terms of use for the API data.
        public class Root
        {
            public Rate rates { get; set; } // This property is intended to hold the exchange rates data retrieved from an API. The 'Rate' class would need to be defined separately to match the structure of the API response.
            public long timestamp;
            public string license;

        }

        public MainWindow()
        {
            InitializeComponent();
            
            GetValue();
        }
        // This method is intended to retrieve exchange rate data from a specified URL (likely an API endpoint) and return it as an instance of the 'Root' class. It uses asynchronous programming to perform the HTTP request without blocking the UI thread.
        public static async Task<Root> GetData<T>(string url)
        {
            // 
            var myRoot = new Root();

            try
            {
                // Create an instance of HttpClient to send HTTP requests and receive responses from a resource identified by a URI. The 'using' statement ensures that the HttpClient instance is disposed of properly after use, which is important for managing resources and avoiding potential memory leaks.
                using (var client = new HttpClient())
                {
                    // Set a timeout for the HTTP request to prevent hanging indefinitely.
                    client.Timeout = TimeSpan.FromMinutes(1); 
                    // Send a GET request to the specified URL and await the response. The response is expected to be in JSON format, which can be deserialized into the 'Root' class structure.
                    HttpResponseMessage response = await client.GetAsync(url);
                    // Check if the response status code indicates success (HTTP 200 OK). If the request was successful, read the response content as a string and deserialize it into an instance of the 'Root' class using a JSON deserialization method (e.g., JsonConvert.DeserializeObject).
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // If the response status code is OK (200), read the response content as a string and deserialize it into an instance of the 'Root' class using a JSON deserialization method (e.g., JsonConvert.DeserializeObject).
                        var ResponceString = await response.Content.ReadAsStringAsync();
                        // Deserialize the JSON response string into an instance of the 'Root' class. This allows you to access the exchange rates and other data contained in the API response through the properties of the 'Root' class.
                        var ResponceObject = JsonConvert.DeserializeObject<Root>(ResponceString);
                        
                        MessageBox.Show("TimeStamp: " + ResponceObject.timestamp, "Information Box", MessageBoxButton.OK, MessageBoxImage.Information);


                        return ResponceObject; // Return the deserialized 'Root' object containing the exchange rates and other data from the API response.
                    }
                    return myRoot;
                }

            }
            catch
            {

                return myRoot; // In case of an exception (e.g., network error, timeout, invalid response), return an empty 'Root' object. This allows the calling code to handle the situation gracefully without crashing the application.
            }




        }
        // This method is intended to retrieve exchange rate data from a specified URL (likely an API endpoint) and store it in the 'val' variable. It uses asynchronous programming to perform the HTTP request without blocking the UI thread. After retrieving the data, it calls the 'BindCurrency' method to populate the currency selection controls with the retrieved exchange rates.
        private async void GetValue()
        {
            // This method is intended to retrieve exchange rate data from a specified URL (likely an API endpoint) and store it in the 'val' variable. It uses asynchronous programming to perform the HTTP request without blocking the UI thread.
            val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=23da65f472f445eea2f5082c5d7a74a9"); 
            BindCurrency();

        }     
        // The 'Rate' class is intended to represent the exchange rates for various currencies. Each property corresponds to a specific currency and its exchange rate relative to a base currency (e.g., USD).
        public class Rate
        {
            public double USD { get; set; }
            public double EUR { get; set; }
            public double GBP { get; set; }
            public double JPY { get; set; }
            public double AUD { get; set; }
            public double CAD { get; set; }
            public double CHF { get; set; }
            public double CNY { get; set; }
            public double SEK { get; set; }
            public double NZD { get; set; }
            public double MXN { get; set; }
            public double SGD { get; set; }
            public double HKD { get; set; }
            public double NOK { get; set; }
            public double KRW { get; set; }
            public double CZK { get; set; }
            public double INR { get; set; }
            public double BRL { get; set; }
            public double ZAR { get; set; }
            public double TRY { get; set; }
            public double RUB { get; set; }
            public double DKK { get; set; }
            public double PLN { get; set; }
            public string LN { get; set; }

        }
        // This method is intended to bind currency data to a ComboBox or similar control. In a real application, this method would likely retrieve exchange rates from an API and populate the ComboBoxes accordingly.
        private void BindCurrency()
        {   
            // This method is intended to bind currency data to a ComboBox or similar control.
            DataTable dt = new DataTable();
            // Adding columns to the DataTable to hold the display text (currency code) and the corresponding exchange rate value.
            dt.Columns.Add("Text");
            // Adding a column to hold the exchange rate value for each currency. This value will be used for calculations when converting between currencies.
            dt.Columns.Add("Value");

            // Adding currency data to the DataTable. In a real application, this data might come from a database or an API.
            dt.Rows.Add("--SELECT--", 0);
            dt.Rows.Add("USD", val.rates.USD);
            dt.Rows.Add("EUR", val.rates.EUR);
            dt.Rows.Add("GBP", val.rates.GBP);
            dt.Rows.Add("JPY", val.rates.JPY);
            dt.Rows.Add("AUD", val.rates.AUD);
            dt.Rows.Add("CAD", val.rates.CAD);
            dt.Rows.Add("CHF", val.rates.CHF);
            dt.Rows.Add("CNY", val.rates.CNY);
            dt.Rows.Add("SEK", val.rates.SEK);
            dt.Rows.Add("NZD", val.rates.NZD);
            dt.Rows.Add("MXN", val.rates.MXN);
            dt.Rows.Add("SGD", val.rates.SGD);
            dt.Rows.Add("HKD", val.rates.HKD);
            dt.Rows.Add("NOK", val.rates.NOK);
            dt.Rows.Add("KRW", val.rates.KRW);
            dt.Rows.Add("CZK", val.rates.CZK);
            dt.Rows.Add("INR", val.rates.INR);
            dt.Rows.Add("BRL", val.rates.BRL);
            dt.Rows.Add("ZAR", val.rates.ZAR);
            dt.Rows.Add("TRY", val.rates.TRY);
            dt.Rows.Add("RUB", val.rates.RUB);
            dt.Rows.Add("DKK", val.rates.DKK);
            dt.Rows.Add("PLN", val.rates.PLN);
            dt.Rows.Add("LN", val.rates.LN);



            // Binding the DataTable to the ComboBox. The DisplayMemberPath specifies which column to display, and the SelectedValuePath specifies which column to use as the value.
            cmbFromCurrency.ItemsSource = dt.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            // Similarly binding the same DataTable to another ComboBox for the target currency.
            cmbToCurrency.ItemsSource = dt.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;


        }
        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            lblCurrency.Content = "Amount Converted!!!";

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
                ConvertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbFromCurrency.SelectedValue.ToString());
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");

            }
        }
        // This method is intended to clear the input fields and reset the ComboBoxes to their default state when the "Clear" button is clicked.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }
        private void ClearControls()
        {
            // This method is intended to clear the input fields and reset the ComboBoxes to their default state.
            txtCurrency.Text = string.Empty; // Clear the text input for currency amount.
            cmbFromCurrency.SelectedIndex = 0; // Reset the source currency ComboBox to the default selection.
            cmbToCurrency.SelectedIndex = 0; // Reset the target currency ComboBox to the default selection.
            lblCurrency.Content = string.Empty; // Clear the label that displays the converted currency result.
        }
        // This method is intended to validate the input for the currency amount, allowing only numeric characters, commas, and periods. It uses a regular expression to check the input and prevents invalid characters from being entered.
        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+"); // Regular expression to allow only numeric input.
            e.Handled = regex.IsMatch(e.Text); // If the input does not match the regex (i.e., it's not a number), mark the event as handled to prevent the input.

        }
    }

}

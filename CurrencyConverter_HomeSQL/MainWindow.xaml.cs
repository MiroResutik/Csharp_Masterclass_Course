using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter_HomeSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
        }
        private void BindCurrency()
        {   // This method is intended to bind currency data to a ComboBox or similar control.
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


            // Binding the DataTable to the ComboBox. The DisplayMemberPath specifies which column to display, and the SelectedValuePath specifies which column to use as the value.
            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;
            // Similarly binding the same DataTable to another ComboBox for the target currency.
            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
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
                ConvertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");

            }
        }
        private void ClearControls()
        {
            // This method is intended to clear the input fields and reset the ComboBoxes to their default state.
            txtCurrency.Text = string.Empty; // Clear the text input for currency amount.
            cmbFromCurrency.SelectedIndex = 0; // Reset the source currency ComboBox to the default selection.
            cmbToCurrency.SelectedIndex = 0; // Reset the target currency ComboBox to the default selection.
            lblCurrency.Content = string.Empty; // Clear the label that displays the converted currency result.
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }
        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.,]+"); // Regular expression to allow only numeric input.
            e.Handled = regex.IsMatch(e.Text); // If the input does not match the regex (i.e., it's not a number), mark the event as handled to prevent the input.

        }
    }
}
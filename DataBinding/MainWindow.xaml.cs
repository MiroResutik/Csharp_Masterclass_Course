using DataBinding.Data;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // One way data binding
        
        // instance of the person class
        Person person = new Person
        {
            Name = "John Doe",
            Age = 30,
            Address = "123 Main St",
            City = "Bristol"
        };
        
        public List<Person> People = new List<Person>
        {
            new Person { Name = "John Doe", Age = 30, Address = "123 Main St", City = "Bristol" },
            new Person { Name = "Jane Smith", Age = 25, Address = "456 Elm St", City = "Bristol" },
            new Person { Name = "Michael Johnson", Age = 35, Address = "789 Oak St", City = "Bristol" },
            new Person { Name = "Emily Davis", Age = 28, Address = "321 Pine St", City = "Bristol" },
            new Person { Name = "David Wilson", Age = 40, Address = "654 Maple St", City = "Bristol" },
            new Person { Name = "Sarah Brown", Age = 22, Address = "987 Cedar St", City = "Bristol" },
            new Person { Name = "James Taylor", Age = 32, Address = "246 Birch St", City = "Bristol" },
            new Person { Name = "Linda Anderson", Age = 27, Address = "135 Spruce St", City = "Bristol" },
        };
        public MainWindow()
        {


            InitializeComponent();

            // Listbox data binding
            ListBoxPeople.ItemsSource = People;
            
            ListBoxNames.ItemsSource = new List<string>()
            {
                "John Doe",
                "Jane Smith",
                "Michael Johnson",
                "Emily Davis",
                "David Wilson",
                "Sarah Brown",
                "James Taylor",
                "Linda Anderson",
            };
            
            // set data context to the person instance
            this.DataContext = person;
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string personData = $"Name: {person.Name}, Age: {person.Age}, Address: {person.Address}, City: {person.City}";
            MessageBox.Show(personData);
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            // 
            var selectedItems = ListBoxPeople.SelectedItems;
            foreach (var item in selectedItems)
            {
                if (item is Person selectedPerson)
                {
                    MessageBox.Show($"Selected Person: {selectedPerson.Name}, Age: {selectedPerson.Age}, Address: {selectedPerson.Address}, City: {selectedPerson.City}");
                }
            };
            //People.Add(new Person { Name = "New Person", Age = 20, Address = "New Address", City = "New City" });
            //ListBoxPeople.Items.Refresh(); // Refresh the ListBox to show the new person
        }


    }
}

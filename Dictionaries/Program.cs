namespace Dictionaries
{
    
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // Different way of Declaring and initilazing Dictionary using string as key and values as well
            var codes = new Dictionary<string, string>
            {
                ["NY"] = "New York",
                ["CA"] = "California",
                ["TX"] = "Texas",
                ["FL"] = "Florida",
                ["IL"] = "Illinois",
                ["PA"] = "Pennsylvania",
                ["OH"] = "Ohio",
                ["MI"] = "Michigan",
                ["GA"] = "Georgia",
                ["NC"] = "North Carolina"
            };

            if (codes.TryGetValue("N1Y", out string state))
            {
                Console.WriteLine(state);
            }
            else
            {
                Console.WriteLine("Code you entered does not exist!");
            }

            foreach (var item in codes)
            {
                Console.WriteLine($"The statecode is {item.Key} and the state name is {item.Value}");
            }
            */
            /*
            // Declaring and initilazing Dictionary and using object rather than string 
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            //Add Item to Dictionary
            employees.Add(1, new Employee("Miro Resutik", 42, 55000));
            employees.Add(2, new Employee("Alice Johnson", 35, 62000));
            employees.Add(3, new Employee("Bob Smith", 29, 48000));
            employees.Add(4, new Employee("Clara Williams", 50, 75000));
            employees.Add(5, new Employee("David Brown", 41, 53000));
            employees.Add(6, new Employee("Emma Davis", 38, 60000));
            employees.Add(7, new Employee("Frank Wilson", 45, 67000));
            employees.Add(8, new Employee("Grace Martinez", 33, 51000));
            employees.Add(9, new Employee("Henry Taylor", 47, 72000));
            employees.Add(10, new Employee("Isabella Anderson", 31, 49000));

            // Iterate through Dictionary
            foreach (var item in employees)
            {
                Console.WriteLine($"ID: {item.Key} Name: {item.Value.Name} {item.Value.Age} years old, earning £{item.Value.Salary} per year!");
            }
            */

            /*
            //Key - value
            // Declaring and initilazing Dictionary
            Dictionary<int, string> employees = new Dictionary<int, string>();

            // Add Item to a Dictionary
            employees.Add(101, "John Doe");
            employees.Add(102, "Bob Smith");
            employees.Add(103, "Alice Johnson");
            employees.Add(104, "Michael Brown");
            employees.Add(105, "Emily Davis");
            employees.Add(106, "David Wilson");
            employees.Add(107, "Sophia Martinez");
            employees.Add(108, "James Anderson");
            employees.Add(109, "Olivia Thomas");
            employees.Add(110, "William Taylor");
            
            // Access items in dictionary
            //string name = employees[101];
            //Console.WriteLine(name);

            // Update data in dictionary
            employees[102] = "Miro Resutik";

            // Remove data from dictionary
            employees.Remove(110);

            // Add employee if duplicate data exists under specific key 
            if (!employees.ContainsKey(104))
            {
                employees.Add(104, "Julia P");
            }

            bool added = employees.TryAdd(105, "Michael Jackson");
            if (!added)
            {
                Console.WriteLine("Employee with the id of 105 already exists!!!");
            }
            /*
            int counter = 101;
            // Loop to find empty Key and add new employee
            while (employees.ContainsKey(counter)) 
            {

                counter++;
            }
            // Add new employee to next empty Key
            employees.Add(counter, "Jesus Christ");
            
            // Iterating through dictionary
            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
            }
            */

            Console.ReadKey();
        }
    }
}

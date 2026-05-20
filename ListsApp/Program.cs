namespace ListsApp
{
    public class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Simple list creation and deletion
            /*
            //// Declaring list and initializing it
            //List<string> colors = new List<string>();
            //// Add items to list
            //colors.Add("Red");
            //colors.Add("Blue");
            //colors.Add("Green");
            //colors.Add("Red");
            //colors.Add("Red");
            //colors.Add("Red");

            // Different way of Declaring list and initializing it
            List<string> colors =
            [
                // Add items to list
                "Red",
                "Blue",
                "Green",
                "Red",
                "Red",
                "Red",
            ];

            Console.WriteLine("Current colors in the colors list!");
            // Loop to dispaly all colors in a list befor deletion
            foreach (string color in colors)
            {

                Console.WriteLine(color);
            }
            // Remove item from the list - only first istance of Red
            bool isDeletingSuccessful = colors.Remove("Red");
            //Deletes all instances of Red
            while (isDeletingSuccessful)
            {
                isDeletingSuccessful = colors.Remove("Red");
            }
                Console.WriteLine("\nCurrent colors in the colors list!");
            // Loop to dispaly all colors in a list
            foreach (string color in colors)
            {
                
                Console.WriteLine(color);
            }
            */
            // Accessing complex data types
            /*
            //products from different class
            List<Product> products = new List<Product>
            {
                new Product {Name = "Apple", Price = 1},
                new Product {Name = "Banana", Price = 2},
                new Product {Name = "Orange", Price = 3},
                new Product {Name = "Milk", Price = 4},
                new Product {Name = "Bread", Price = 1},
                new Product {Name = "Eggs", Price = 5},
            };
            // Dispaly complex data types from other class
            Console.WriteLine("Available Products: ");
            foreach (Product product in products)
            {
                Console.WriteLine($"Product name is: {product.Name} at price £{product.Price}");
            }

            //System link
            List<Product> cheapProducts = products.Where(p => p.Price < 2).ToList();//.ForEach(p => Console.WriteLine(p.Name));
            Console.WriteLine("\nCheapest Products: ");
            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"Product name is: {product.Name} at price £{product.Price}");
            }
            */
            // Sorting Lists, Lambda expresion
            /*
            List<int> numbers = new List<int> {1,5,15,12,16,4,47,11,2,97,88 };
            //Unsorted list 
            Console.WriteLine("Unsorted list!");
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            // Delegate is like a pinter or a reference to a method
            // It allows to pass methods as argument to other methods, store them in variables and call them later

            // ANY - determines wheterh ANY alement of a sequence exists or satisfies a condition
            bool isGreaterThan40 =  numbers.Any(x => x > 40);

            if (isGreaterThan40)
            {
                Console.WriteLine("\nThere are numbers larger than 40 in the list!");
            } else {
                Console.WriteLine("\nNo numbers larger than 40 in the list");
            }

            //Define the predicate to check if a number is grater than 10
            Predicate<int> isGreaterThan20 = x => x >= 20;

            List<int> isGreaterThan = numbers.FindAll(isGreaterThan20);
            // Number higher than 40
            Console.WriteLine("\nNumbers higher than 20");

            foreach (int i in isGreaterThan)
            {
                Console.WriteLine(i);
            }

            // Lambda expresion - This will return list of numbers larger than 10
            List<int> higherOrEqualTen = numbers.FindAll(x => x >= 10);
            // Number higher than 10
            Console.WriteLine("\nNumbers higher than 10");
      
            foreach (int i in higherOrEqualTen)
            {
                Console.WriteLine(i);
            }
            //Sorted list
            Console.WriteLine("\nSorted list!");
            numbers.Sort();

            foreach  (int i in numbers)
            {
                Console.WriteLine(i);
            }
            */
            // Lambda expressions
            /*
            // Lambda expression consists of 1.Parameters and 2. Expression or Statement Block
            //Parameters are on the left of => and the experssion or action to perform is on the right
            // This read as: Take an input x and turn it into x multiplied by x - x=> x * x;
            //This is used when it is only used once

            // Only use the method when it is called multiple times in the code
            static int Squaring(int x)
            {
                return x * x; 
            }
            */
            Console.ReadKey();
        }
    }
}

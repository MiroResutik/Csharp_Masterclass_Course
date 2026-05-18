namespace CalassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Rectangle rectangle1 = new Rectangle("Red");
            Rectangle rectangle2 = new Rectangle("Blue");

            rectangle1.DispalyDetails();
            rectangle2.DispalyDetails();

            /*
            Customer customer1 = new Customer();
            Customer customer2 = new Customer("Miro", "Brezno", "0788");
            Customer customer3 = new Customer("Earl", "Earl street", "");
             
            customer1.GetDetails();
            customer2.GetDetails();
            customer3.GetDetails();

            // Assign password to user
            customer3.Password = "1234";

            Console.WriteLine("Customer 3 id number is: " +customer3.Id);
            */

            /*
            Car car = new Car();
            Car car1 = new Car("Brera", "Alfa Romeo", "3.2L", "V6", true);
            Car car2 = new Car("A3", "Audi", "4.4L", "V8", true);

            //Accessing the public static variable NubmerOfCars fo the Car class
            Console.WriteLine("\nNumber of cars produced: " + Car.NumberOfCars);
            */

            /*
            Console.WriteLine(AddNum(15,25));
            //Named Parameter
            Console.WriteLine(AddNum(num1: 23,25));
            
            Rectangle rectangle1 = new Rectangle();
            rectangle1.Width = 5;
            rectangle1.Height = 5;
            //This would never work as we never set the Area
            //rectangle1.Area = 5;
            Console.WriteLine($"Area of the rectangel is: {rectangle1.Area}");
            */
            /*
            //Object of the Customer class
            Customer earl = new Customer("Earl", "Earl street", "");
            Customer miro = new Customer("Miro", "Bristol", "07912028579");

            //Default Customer with no Arguments given
            //Create object using the contructer
            Customer myCustomer = new Customer();
            Console.WriteLine("Please enter the customer name, address and number! Hit enter after each one!");

            myCustomer.SetDetails("Miro", "Main street");

            Console.WriteLine($"MyCustomer is: {myCustomer.Name} and lives at {myCustomer.Address} number {myCustomer.ContactNumber}");
            //myCustomer.Name = Console.ReadLine();
            //myCustomer.Address = Console.ReadLine();
            //myCustomer.ContactNumber = Console.ReadLine();
            //Console.WriteLine("Deatail about customer: " + earl.Name+" " +earl.Address+ " "+earl.ContactNumber);
            //Console.WriteLine("Customer name is : "+ earl.Name);
            //Console.WriteLine("Customer name is : " + miro.Name + " " +miro.Address+" "+miro.ContactNumber);
            */
            

            /*
            //Creating an Object of the Clsss car
            //Careating an instance of the Class car
            Car audi = new Car("A3", "Audi", "4.4L", "V8", true);
            Car bmw = new Car("M3", "BMW", "3.2L", "V6", true);

            //Console.WriteLine("Enter the Brand name: ");
            //Setting Brand
            //audi.Brand = Console.ReadLine();

            //Getting Brand
            Console.WriteLine("You entered " + audi.Brand);
            Console.WriteLine("You entered " + bmw.Brand);
            */
            /*
            //Object can have properties(attributes of that object) and methods (capabilities)
            //Careating an instance of the Class car
            Car myAudi = new Car("A3", "Audi", "4.4L", "V8", true);
            //Use method on top of the class
            myAudi.Drive();

            Car myBmw = new Car("M3", "BMW", "3.2L", "V6", true);
            myBmw.Drive();
            */
            Console.ReadKey();
        }
        /*
        //Read only property
        static int AddNum(int num1, int num2)
        {
            return num1 + num2;
        }
        */
    }
}

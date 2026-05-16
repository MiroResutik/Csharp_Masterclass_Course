namespace CalassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Object
            Customer earl = new Customer("Earl");
            Customer miro = new Customer("Miro", "Bristol", "07912028579");

            //Default Customer with no Arguments given
            //Create object using the contructer
            Customer myCustomer = new Customer();
            Console.WriteLine("Please enter the customer name, address and number! Hit enter after each one!");

            myCustomer.Name = Console.ReadLine();
            myCustomer.Address = Console.ReadLine();
            myCustomer.ContactNumber = Console.ReadLine();
            Console.WriteLine("Deatail about customer: " + myCustomer.Name+" " +myCustomer.Address+" "+myCustomer.ContactNumber);
            //Console.WriteLine("Customer name is : "+ earl.Name);
            //Console.WriteLine("Customer name is : " + miro.Name + " " +miro.Address+" "+miro.ContactNumber);
            Console.ReadLine();
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

            //Object can have properties(attributes of that object) and methods (capabilities)
            //Careating an instance of the Class car
            Car myAudi = new Car("A3", "Audi", "4.4L", "V8", true);
            //Use method on top of the class
            myAudi.Drive();

            Car myBmw = new Car("M3", "BMW", "3.2L", "V6", true);
            myBmw.Drive();
            Console.ReadKey();
        }
    }
}

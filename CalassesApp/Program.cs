namespace CalassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating an Object of the Clsss car
            //Careating an instance of the Class car
            Car audi = new Car("A3","Audi", "4.4L", "V8", true);
            Car bmw = new Car("M3","BMW", "3.2L", "V6", true);

            //Console.WriteLine("Enter the Brand name: ");
            //Setting Brand
            //audi.Brand = Console.ReadLine();

            //Getting Brand
            Console.WriteLine("You entered " + audi.Brand);
            Console.WriteLine("You entered " + bmw.Brand);
            Console.ReadKey();
        }
    }
}

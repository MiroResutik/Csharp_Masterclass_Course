namespace StructsApp
{
    public struct Point
    {
        //It's a common practice to make structs immutable
        //by declaring all fields as readonly and providing only get accessors for properties.
        //However, for demonstration purposes, we will keep it mutable.
        //Properties
        //public int X { get; set; }
        //public int Y { get; set; }

        //public int X;
        //public int Y;

        public double X { get; }
        public double Y { get; }
        //Constructor
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        //Methods
        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
            
        }

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(3, 4);
            p1.Display();

            //all fields of a struct are automatically initialized to their default values,
            //so we can create an instance without using the constructor and then assign values to its fields.
            Point p2 = new Point(20,30); 
            //p2.X = 5;
            //p2.Y = 6;
            p2.Display();

            //Get the distance between two points
            double distance = p1.DistanceTo(p2);

            Console.WriteLine($"Distance between p1 and p2: {distance:F2}"); // F2 - formats the output to 2 decimal places

            Point p3 = p1; // This will copy the values of p1 into p3   
            //p3.X = 7;
            //p3.Y = 6;
            p1.Display(); // Output: Point: (3, 4)  
            p3.Display();  
            
            Console.ReadKey();

        }
    }
}

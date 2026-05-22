namespace DependencyInjectionApp
{
    //Multiple Inheritance

    public interface IPrintable
    {
        void Print();
    }
    public interface IScannable
    {
        void Scan();
    }

    public class MultiFunctionPrinter: IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Printing document....");
        }
        public void Scan()
        {
            Console.WriteLine("Scanning document....");
        }

    }
    // Dependency Injections
    //Interface injection
    /*
    public interface IToolUser
    {
        void SetHammer(Hammer hammer);
        void SetSaw(Saw saw);
    }
    public class Hammer
    {
        public void Use()
        {
            Console.WriteLine("Hammering Nails!");
        }
    }
    public class Saw
    {
        public void Use()
        {
            Console.WriteLine("Sawing wood!");
        }
    }
    */
    /*
    //Constructor Dependency injection
    //Hammer and Saw are Builder dependencies with injection - (Hammer hammer, Saw saw)
    public class Builder: IToolUser // : IToolUser - Interface injection
    {
        //Using Dependency Interface injection properties
        private Hammer _hammer;
        private Saw _saw;

        ////Using setter injection properties
        //public Hammer Hammer { get; set; }
        //public Saw Saw { get; set; }

        ////Using Dependency injector properties
        //private Hammer _hammer;
        //private Saw _saw;

        //Setter DI

        //Constructor Dpendency Injection DI
        /*
        public Builder(Hammer hammer, Saw saw)
        {
            _hammer = new Hammer(); // Builder is resposible for creating its dependencies
            _saw = new Saw();
        }
        */
    /*
        public void BuildHouse()
        {
            //Dpendency Interface Injection DI
            _hammer.Use();
            _saw.Use();

            ////Dpendency Injection DI
            //_hammer.Use();
            //_saw.Use();

            //// Setter DI
            //Hammer.Use();
            //Saw.Use();
            Console.WriteLine("\nHouse built!");
        }
        //Dependency Interface injection
        public void SetHammer(Hammer hammer)
        {
            _hammer = hammer;
            //throw new NotImplementedException();
        }
        //Dependency Interface injection
        public void SetSaw(Saw saw)
        {
            _saw = saw;
            //throw new NotImplementedException();
        }
        
    }
 */
    internal class Program
    {
        static void Main(string[] args)
        {
            //Multiple Inheritance
            MultiFunctionPrinter printer = new MultiFunctionPrinter();
            printer.Print();
            printer.Scan();

            //Dependency Injection
            /*
            Hammer hammer = new Hammer();//Create the dependencies outside
            Saw saw = new Saw();
            //Builder builder = new Builder(hammer, saw); //Dpendency Injection DI
            // Setter DI
            Builder builder = new Builder(); 
            //builder.Hammer = hammer; //Inject dpendencies via Setters
            //builder.Saw = saw; //Inject dpendencies via Setters
            builder.SetHammer(hammer); //Inject interface dpendencies
            builder.SetSaw(saw); //Inject interface dpendencies

            builder.BuildHouse();
            */
            Console.ReadLine();
        }
    }
}

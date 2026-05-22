using System.Net;

namespace InheritanceApp
{
    //Interfaces and Polymorphism



    //Decoupling
    /*
    //Decoupling: The Application class depend on the ILogger interface rather than
    //specific implementation like FileLogger or DatabaseLogger.
    //This mean you can easily switch the logging mechanism without changing the Application class

    //Logger Application
    public interface ILogger
    {
        void Log(string message);
    }
    //Implementation of FileLogger
    public class FileLogger: ILogger
    {
        //Log method
        public void Log(string message) 
        {
            string directoryPath = @"C:\Users\Miro\source\repos\Logs";
            string filePath = System.IO.Path.Combine(directoryPath, "Log.txt");
            //string logMessage = "Hello World!!!\nNew Log file created!!!" + "\n";

            // If directory does not exist create new one
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //Log text in filePath
            File.AppendAllText(filePath, message);

        }

    }
    // Database logger
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            //Implement the logic to log a message to a database
            Console.WriteLine($"Logging to database... {message}");
        }
    }

    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Log work started...");
            //Do all the work
            _logger.Log("Work Done!!!");
        }
    }
    */
    //Payment processor app
    /*
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            //Implement credit card payment logic
            Console.WriteLine($"Processing credit card payment of amount: £{amount}");
        }
    }
    public class PaypalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing Paypal payment of amount: £{amount}");
        }
    }
    // Iterface class
    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;
        // Constructor
        public PaymentService(IPaymentProcessor processor)
        {
            _processor = processor;
        }
        //Method to process payment
        public void ProcessPayment(decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }
    */
    //Polymorphism
    /*
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }
    */
    //Interfaces
    /*
    //Interface method
    public interface IAnimal
    {
        //Non implemented method declaration
        void MakeSound();
        void Eat(string food);
    }

    public class Dog : IAnimal
    {
        //Implement Interfaces
        public void Eat(string food)
        {
            Console.WriteLine("Dog ate: " +food);
            //throw new NotImplementedException();
        }

        public void MakeSound()
        {
            Console.WriteLine("Bark...");
            //throw new NotImplementedException();
        }
    }
    public class Cat : IAnimal
    {
        //Implement Interfaces
        public void Eat(string food)
        {
            Console.WriteLine("Cat ate: " + food);
            //throw new NotImplementedException();
        }

        public void MakeSound()
        {
            Console.WriteLine("Meaw...");
            //throw new NotImplementedException();
        }
    }
    */
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Decoupling
            /*
            //Logger Constructor
            ILogger fileLogger = new FileLogger();
            Application application = new Application(fileLogger);
            application.DoWork();

            ILogger databaseLogger = new DatabaseLogger();
            Application database = new Application(databaseLogger);
            database.DoWork();
            */
            //Storing Log file in local directory
            /*
            //The @ sign in C# is used to denote a verbatim string literal
            string directoryPath = @"C:\Users\Miro\source\repos\Logs";
            string filePath = System.IO.Path.Combine(directoryPath, "Log.txt");
            string logMessage = "Hello World!!!\nNew Log file created!!!" + "\n";

            // If directory does not exist create new one
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            //Log text in filePath
            File.AppendAllText(filePath, logMessage);
            */
            //Interface reusability
            /*
            //Polymorphism
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            //Pass creditCardProcessor as constructor
            PaymentService paymentServiceCreditCard = new PaymentService(creditCardProcessor);
            paymentServiceCreditCard.ProcessPayment(100.00m);
            //Paypal processor
            IPaymentProcessor paypalProcessor= new PaypalProcessor();
            PaymentService paymentServicePaypal = new PaymentService(paypalProcessor);
            paymentServicePaypal.ProcessPayment(200.00m);
            */
            // Polymorphism - simple example
            /*
            // Part 2 of Polymorphism
            //Create Animal object but store a Dog object in it
            Animal myAnimal = new Dog();
            myAnimal.MakeSound();
            */
            //Interfaces
            /*
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("Treat");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("Mouse");
            */
            //Inheritance
            /*
            //Employee joe = new Employee("Joe", 40, "Sales Rep", 111);
            //joe.DispalyEmployeeInfo();

            Manager carl = new Manager("Carl", 45, "22 City Street", "Bristol", "Manager", 222, 7);
            carl.DispalyManagerInfo();
            carl.BecomeOlder(50);
            carl.DisplayPersonInfo();   

            Manager anna = new Manager("Anna", 38, "15 Oak Avenue", "Bristol", "Manager", 223, 5);
            anna.DispalyManagerInfo();

            Manager ben = new Manager("Ben", 50, "9 Maple Road", "Bristol", "Manager", 224, 10);
            ben.DispalyManagerInfo();

            Manager claire = new Manager("Claire", 42, "33 Pine Lane", "Bristol", "Manager", 225, 6);
            claire.DispalyManagerInfo();

            Manager david = new Manager("David", 47, "7 Elm Street", "Bristol", "Manager", 226, 8);
            david.DispalyManagerInfo();

            Console.WriteLine(carl.ToString());
            */
            //Access modifiers and Protected keywords
            /*
            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();
            

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessFields();
            derivedClass.ShowFields();
            */
            //Parent class and Child class
            /*
            Dog myDog = new Dog();
            myDog.MakeSound();
            //myDog.Eat();
            
            Cat myCat = new Cat();
            myCat.MakeSound();
            */
            Console.ReadKey();
        }
    }

    // Inheritance Constructors
    /*
    public class Person
    {
        //Get and set properties
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }

        //Base class Constructor
        public Person(string name, int age, string address, string city)
        {
            //Console.WriteLine("1. Person coonstructor called");
            Name = name;
            Age = age;
            Address = address;
            City = city;
        }

        public void DisplayPersonInfo()
        {

            Console.WriteLine($"\n3. Name {Name},age - {Age}, address - {Address} city - {City}");
        }

        // XML comments for developers 
        /// <summary>Makes our object older!</summary>
        /// <param name="years">The parameter that idicates the amout of years the object should age</param>
        /// <returns>Returns the new age after aging/becoming older</returns>
        public int BecomeOlder(int years)
        {
            Age = Age + years;
            return Age;
        }



    }
    // Derived class constructor
    public class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }

        //Calling the base class constructor
        public Employee(string name, int age, string address, string city, string jobTitle, int employeeID) : base(name, age, address, city)
        {
            //Console.WriteLine("\n2. Employee (Derived class) constructor called!");
            JobTitle = jobTitle;
            EmployeeID = employeeID;
        }
        public void DispalyEmployeeInfo()
        {
            //Call method from base class
            DisplayPersonInfo();
            Console.WriteLine($"\n4. Job Title: {JobTitle}, Employee ID: {EmployeeID}");
        }
    }
    // Derived class constructor
    public class Manager : Employee
    {
        public int TeamSize {  get; private set; }

        public Manager(string name, int age, string address, string city, string jobTitle, int employeeID , int teamSize) : base(name, age, address, city,jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }
        public void DispalyManagerInfo()
        {
            //Call method from base class
            DispalyEmployeeInfo();
            Console.WriteLine($"Team size {TeamSize}");
        }
    }
    */

        //Access modifiers and Protected keywords
        /*
        class BaseClass
        {
            //access modifiers
            public int publicField;
            protected int protectedField;
            private int privateField;

            public void ShowFields()
            {
                Console.WriteLine($"Public: {publicField}, Protected: {protectedField}, Private: {privateField}");
            }
        }
        class DerivedClass : BaseClass
        {
            public void AccessFields()
            {
                publicField = 1;
                protectedField = 2;
                //privateField = 3; // inaccessable. Derived class cannot access fields that are private
            }
        }
        */
        //Parent class and Child class
        /*
        // Base Class (Parent class or superclass): 
        class Animal
        {

            public void Eat()
            {
                Console.WriteLine("Eating...");
            }
            //virtual allows to overwrite the Makesound method in derived Class
            public virtual void MakeSound()
            {
                Console.WriteLine("Animal makes a generic sound");
            }
        }

        // Derived Class (Child class or subclass): Inherits the memebers from base Class - Animal class
        class Dog: Animal
        {
            // override 
            public override void MakeSound()
            {
                base.MakeSound(); // access the base class
                Console.WriteLine("Barking....");
            }
        }
        // Derived Class (Child class or subclass): Hiracical inheritance
        class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Meowing....");
            }
        }

        class Collie: Dog
        {
            public void GoingNuts()
            {
                Console.WriteLine("Collie going Nuts");
            }
        }
        */

    }

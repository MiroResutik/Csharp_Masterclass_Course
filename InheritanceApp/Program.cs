namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee joe = new Employee("Joe", 40, "Sales Rep", 111);
            joe.DispalyEmployeeInfo();
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

    // Constructors

    public class Person
    {
        //Get and set properties
        public string Name { get; private set; }
        public int Age { get; private set; }

        //Base class Constructor
        public Person(string name, int age)
        {
            Console.WriteLine("1. Person coonstructor called");
            Name = name;
            Age = age;
        }

        public void DisplayPersonInfo()
        {

            Console.WriteLine($"\n3. Name {Name} and age {Age}");
        }



    }
    // Derived class constructor
    public class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }

        //Calling the base class constructor
        public Employee(string name, int age, string jobTitle, int employeeID) : base(name, age)
        {
            Console.WriteLine("\n2. Employee (Derived class) constructor called!");
            JobTitle = jobTitle;
            EmployeeID = employeeID;
        }
        public void DispalyEmployeeInfo()
        {
            //Call method from base class
            DisplayPersonInfo();
            Console.WriteLine($"\nJob Title: {JobTitle}, Employee ID: {EmployeeID}");
        }
    }



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

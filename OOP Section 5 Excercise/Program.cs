namespace OOP_Section_5_Excercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Miro", 40);
            person.Greet();
        }
    }

    public class Person
    {
        private string _name;
        private int _age;

        // Public property for Name
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //Public property for _age
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }
        //Constructor to create Person
        public Person(string name, int age)
        {
            _name = name;
            Age = age;
        }
        //Greet method
        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }
}

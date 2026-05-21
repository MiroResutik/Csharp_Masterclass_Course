namespace Advanced_Method_Overriding_Exercise_Section_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.MakeSound();

            Dog myDog = new Dog();
            myDog.MakeSound();

            Cat myCat = new Cat();
            myCat.MakeSound();
        }
    }
    public class Animal // Defining the Animal class
    {
        public virtual void MakeSound() // Virtual method that can be overridden in derived classes
        {
            // Default implementation for making a sound
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal // Defining the Dog class that inherits from Animal
    {
        public override void MakeSound() // Overriding the MakeSound method in the Animal class
        {
            // Specific implementation for Dog making a sound
            Console.WriteLine("Dog barks");
        }
    }
    public class Cat : Animal // Defining the Cat class that inherits from Animal
    {
        public override void MakeSound() // Overriding the MakeSound method in the Animal class
        {
            // Specific implementation for Cat making a sound
            Console.WriteLine("Cat meows");
        }
    }

}

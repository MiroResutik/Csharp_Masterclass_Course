namespace DelegatesAndEvents
{

    // Delegates and Generics to make sorting algorithms more flexible and reusable.
    /*
    public delegate int Comparison<T>(T x, T y); // A generic delegate for comparison

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        ////public Person(string name, int age)
        //{
        //    Name = name;
        //    Age = age;
        //}
    }
    public class PersonSorter
    {
        public void Sort(Person[] people, Comparison<Person> comparison)
        {
            // Simple bubble sort for demonstration
            for (int i = 0; i < people.Length - 1; i++) // Outer loop to traverse the array 
            {
                for (int j = i + 1; j < people.Length; j++) // Inner loop to compare adjacent elements
                {
                    if (comparison(people[i], people[j]) > 0) // Using the comparison delegate to determine the order
                    {
                        // Swap the elements if they are in the wrong order
                        Person temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }
        }
    }
    */
    internal class Program
    {
        // Delegates and events
        
        //Delegates define a method signature,
        // and any method assigned to a dolegate must match that signature.

        //1. Declare a delegate type that matches the signature of the methods you want to call.
        // Declaration can be done outside of the class or inside the class, but outside of any method.
        public delegate void Notify(string message);

        public delegate void LogHandler(string logMessage);

        public class Logger
        {
            // Declaration of a delegate instance must be same as the delegate type defined above.
            public void LogToConsole(string message)
            {
                Console.WriteLine($"\nConsole Log: {message}");
            }
            public void LogToFile(string message)
            {
                // Simulate logging to a file (for demonstration purposes)
                Console.WriteLine($"\nFile Log: {message}");
            }
        }
        

        static void Main(string[] args)
        {
            // Delegates and Generics
            
            // Generics Example:
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] stringArray = { "Hello", "World", "Generics", "C#" };

            PrintArray(intArray); // Using the generic method to print an array of integers 
            PrintArray(stringArray); // Using the generic method to print an array of strings

            // Delegates Example:
            /*
            Logger logger = new Logger();
            LogHandler logHandler = logger.LogToConsole; // Assigning the method to the delegate instance
            logHandler("\nThis is a log message to the console.");

            logHandler = logger.LogToFile; // Reassigning the delegate instance to another method
            logHandler("\nThis is a log message to the file.");
            */
            //Multicast Delegates: A delegate can reference multiple methods. When the delegate is invoked, it will call all the methods it references in order.
            Logger logger = new Logger();
            LogHandler logHandler = logger.LogToConsole; // Assigning the method to the delegate instance
            logHandler += logger.LogToFile; // Adding another method to the delegate instance (multicast)

            // Invoking the multicast delegate will call both methods in the order they were added.
            logHandler("\nThis is a log message to both console and file using multicast delegate.");

            foreach (LogHandler handler in logHandler.GetInvocationList()) // Iterating through the invocation list of the multicast delegate
            {
                try
                {
                    handler("Event occured with error handling!!!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Exception caught: " +ex.Message);
                }
                //Console.WriteLine($"\nInvoking method: {handler.Method.Name}"); // Displaying the name of each method in the invocation list
            }
            // Removing a method from the delegate instance

            if (IsMethodInDelegate(logHandler, logger.LogToFile)) // Checking if the method is in the delegate before attempting to remove it
            {
                logHandler -= logger.LogToFile; // Removing the method from the delegate instance
                Console.WriteLine("\nLogToFile method removed from the delegate instance.");
            }
            else
            {
                Console.WriteLine("\nLogToFile method is not found in the delegate instance.");
            }
            //logHandler -= logger.LogToConsole; 

            //Safer way of removing deleate
            //InvokeSafely(logHandler, "\nThis is a log message to the file only after removing the console log method from the delegate instance using safe invocation.");

            //logHandler("\nThis is a log message to the file only after removing the console log method from the delegate instance.");

            //2. Instantiation:
            Notify notifyDelegate = ShowMessage; //Directly assigning the method to the delegate


            // 3. Invocation: Calling the delegate will invoke the assigned method(s).
            notifyDelegate("\nHello, this is a message from the delegate!");
            

            // Delegates and Generics to make sorting algorithms more flexible and reusable.
            /*
            Person[] people =
            {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Charlie", Age = 35 },
                new Person { Name = "David", Age = 28 },
                new Person { Name = "Eve", Age = 22 },
                new Person { Name = "Frank", Age = 40 },
                new Person { Name = "Grace", Age = 27 },
                new Person { Name = "Heidi", Age = 32 },
            };

            PersonSorter sorter = new PersonSorter();
            sorter.Sort(people, CompareByAge);
            Console.WriteLine("\nArray sorted by Age: ");

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}");
            }

            sorter.Sort(people, CompareByName);
            Console.WriteLine("\nArray sorted by Name: ");

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}");
            }
            */
            Console.ReadKey();
        }

        // Invoke the delegate to call the method
        /*
        static void InvokeSafely(Notify logHandler, string message)
        {
            LogHandler tempLogHandler = logHandler; // Create a temporary copy of the delegate instance to

            if (logHandler != null) // Check if the delegate is not null before invoking
            {
                logHandler(message); // Invoke the delegate
            }
            else
            {
                Console.WriteLine("\nNo method assigned to the delegate.");
            }
        }   
        */
        // A safer way to invoke a delegate is to use the null-conditional operator (?.) which checks if the delegate is null before invoking it.
        static bool IsMethodInDelegate(LogHandler logHandler, LogHandler method)
        {
            if (logHandler == null || method == null) // Check if either the delegate or the method is null
            {
                return false; // If either is null, return false
            }
            foreach (var d in logHandler.GetInvocationList()) // Iterating through the invocation list of the delegate
            {
                if (d == (Delegate)method) // Checking if the method name matches the specified name
                {
                    return true; // Method is found in the delegate
                }
            }
            return false; // Method is not found in the delegate
        }
        // Delegates and Generics

        // Method that matches the delegate signature
        static void ShowMessage(string message1) // The parameter name can be different from the delegate definition
        {
            Console.WriteLine($"\nMessage: {message1}");
        }
        // Generics 
        public static void PrintIntArray(int[] arr)
        {
            Console.WriteLine("\nArray elements:");
            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
        public static void PrintStringArray(string[] arr)
        {
            Console.WriteLine("\nArray elements:");
            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
        }
        // Generics method that can print any type of array
        public static void PrintArray<T>(T[] array)
        {
            Console.WriteLine("\nArray elements using Generics:");
            foreach (T element in array)
            {
                Console.WriteLine(element);
            }
        }
        

        // Delegates and Generics to make sorting algorithms more flexible and reusable.
        /*
        static int CompareByAge(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }

        static int CompareByName(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
        */
    }
}

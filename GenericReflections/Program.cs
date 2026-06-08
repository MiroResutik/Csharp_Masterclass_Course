using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace GenericReflections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Predicate generic delegate

            Predicate<int> isEven = (x) => { return x % 2 == 0; };

            Console.WriteLine("\nNumber is even: "+isEven(5));

            //Function generic delegate
            /*
            Func<string> getName = () => { return "Miro!!!"; };
            
            var myName = getName();
            Console.WriteLine(myName);

            Func<int, int, int> sum = (x, y) => 
            { 
                return (x + y); 
            };
            Console.WriteLine(sum(3,5));
            */
            // Action generic delegate
            /*
            Action action = () =>  Console.WriteLine("\nAction - generic delegate!!!");

            action();

            Action<int> numPrint = (x) => { Console.WriteLine(x); };

            numPrint(10);

            Action<float, int, float> sum = (x, y, z) =>  Console.WriteLine(x + y + z);
            sum(10, 10, 10);
            */

            // Generic reflections
            //Type type = typeof(ConfigurationManager<>);
        }
    }
    // Generic reflections
    /*
    internal class ConfigurationManager<T>
    {
        public T LoadedConfiguration { get; set; }
        public ConfigurationManager(T config)
        {
            LoadedConfiguration = config;
        }
        public static void SaveConfiguration(T configToSave)
        {

        }

    }
    */
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = { 14, 3, 19, 7, 1, 12, 20, 5, 16, 9, 2, 18, 11, 4, 15, 8, 13, 6, 17, 10 };

            OddNumbers(numbers);

            // LINQ query to sort the numbers in ascending order
            IEnumerable<int> sortedInts = from i in numbers orderby i select i;

            Console.WriteLine("\nSorted numbers in array:");
            foreach (int i in sortedInts)
            {

                Console.WriteLine(i);
            }
            // LINQ method syntax to sort the numbers in ascending order
            IEnumerable<int> reverseInts = sortedInts.Reverse();

            Console.WriteLine("\nReversed numbers in array:");
            foreach (int i in reverseInts)
            {
                
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
        // Method to find and display odd numbers from the array
        static void OddNumbers(int[] numbers)
        {
            

            IEnumerable<int> oddNumbers = from n in numbers
                                          where n % 2 != 0
                                          select n;



            Console.WriteLine("\nOdd numbers:");
            foreach (var num in oddNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}

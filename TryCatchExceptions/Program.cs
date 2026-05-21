using System.Diagnostics;

namespace TryCatchExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //How Exceptions Work with the Call Stack

            Console.WriteLine("App running before the try block");
            try
            {
                LevelOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in Main: " + ex.Message);
            }
            Console.WriteLine("App is still running!");
            Console.ReadKey();
        }

        static void LevelOne()
        {
            LevelTwo();
        }

        static void LevelTwo()
        {
            Console.WriteLine("Level two before throw!");
            throw new FormatException("Something went wrong!");
            Console.WriteLine("Level two After throw!");
        }

        //Try catch
        /*
        int result = 0;

        Debug.WriteLine("Main method is running");

        try
        {
            Console.WriteLine("Please enter a number");
            int num1 = int.Parse(Console.ReadLine());
            //int num1 = 0;
            int num2 = 2;
            result = num2 / num1;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("DONT DIVIDE BY ZERO!!! " + ex.Message);
            result = 10;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("I TOLD YOU TO ENTER A NUMBER!" + ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("NUMBER TOO HIGH!");
        }
        // Parent exception to catch all exceptions
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.ToString());
            // This next line is only executed during "Debugging"

        }
        finally
        {
            // Code to cleanup or finalize
            // ideal for cleaning up resources,
            // like closing file streams or database connections.

            Console.WriteLine("This always executes");
        }

        // Don't forget to listen to these trace messages

        Console.WriteLine("Result: " + result);
        */
        //Console.ReadKey();

        //Error Handling exercise Section 7
        /*
        public void HandleMultipleExceptions(string numberString, int index)
        {
            int[] numbers = { 1, 2, 3 }; // Array for accessing elements
            try
            {
                // May throw FormatException
                int number = int.Parse(numberString);

                Console.WriteLine(numbers[index]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range.");
            }
        }
        */
    }
}


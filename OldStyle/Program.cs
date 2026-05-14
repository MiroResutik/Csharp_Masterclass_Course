namespace OldStyle
{
    // Access modifier
    internal class Program
    {
        static int myResult; // Made static

        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer: ");
            int num1 = int.Parse(Console.ReadLine());

            myResult = AddTwoValues(num1, 10);
            Console.WriteLine("The result is " + myResult);

            Console.ReadKey();
        }

        static int SubtractTwoValues(int value1, int value2)
        {
            myResult = value1 - value2;
            return myResult;
        }

        static int AddTwoValues(int value1, int value2)
        {
            myResult = value1 + value2;
            return myResult;
        }
    }
}

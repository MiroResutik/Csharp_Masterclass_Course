namespace CalculateAverageTempExcercise
{
    internal class Program
    {
        // Method to calculate the average temperature
        static double CalculateAverage(double[] temperatures)
        {
            double sum = 0;

            // Loop through the array and add all temperatures
            foreach (double temp in temperatures)
            {
                sum += temp;
            }

            // Calculate and return the average
            return sum / temperatures.Length;
        }

        // Method to print the average temperature
        static void PrintAverage(double[] temperatures)
        {
            double average = CalculateAverage(temperatures);

            Console.WriteLine("The average temperature is: " + average);
        }

        static void Main()
        {
            // Default array of temperatures
            double[] temperatures = { 20.5, 22.0, 25.5, 26.0 };

            // Call method to print the average
            PrintAverage(temperatures);
        }
    }
}

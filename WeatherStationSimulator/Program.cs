namespace WeatherStationSimulator
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of day to simulate: ");
            int days = int.Parse(Console.ReadLine());

            int[] temperature = new int[days];
            string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy", "Overcast", "Hnusne" };
            string[] weatherconditions = new string[days];
            

            Random random = new Random();

            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(-10, 40);
                weatherconditions[i] = conditions[random.Next(conditions.Length)];
            }


        }
    }
}

namespace WeatherStationSimulator
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of day to simulate: ");
            int days = int.Parse(Console.ReadLine());

            int[] temperature = new int[days];
            string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy", "Overcast", "Hnusne","Nadherne","Windy" };
            string[] weatherconditions = new string[days];
            

            Random random = new Random();

            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(-10, 40);
                weatherconditions[i] = conditions[random.Next(conditions.Length)];
            }

            //Get maximum and minimum value in the array tmperature[i]
            temperature.Max();
            //temperature.Min();
            //double averageTemp = CalculateAverage(temperature);

            Console.WriteLine($"\nAverage Temperature is: {CalculateAverage(temperature)}");
            Console.WriteLine($"\nThe maximum temperature is: {temperature.Max()}");
            Console.WriteLine($"\nThe minimum temperature is: {MinTemperature(temperature)}");
            Console.WriteLine($"\nMost common condition is: {MostCommonCodition(conditions)}");
            Console.ReadKey();
        }

        //Method to dispaly conditions
        static string MostCommonCodition(string[] conditions)
        {
            int count = 0;

            string mostCommon = conditions[0];
        //Loop through all coditions - 
            for (int i = 0; i < conditions.Length; i++)
            {
                // Lets say 1st iteration is "Sunny"
                int tempCount = 0;
                //Loop to check how many times is "Sunny" in the array or loop
                for (int j = 0; j < conditions.Length; j++)
                {
                    if (conditions[j] == conditions[i])
                    {
                        tempCount++;
                    }
                }
                //Temporary count of "Sunny" and add to count
                if (tempCount > count)
                {
                    count = tempCount;
                    mostCommon = conditions[i];
                }
            }
            return mostCommon;
        }

        static double CalculateAverage(int[] temperature)
        {
            int sum = 0;

            //loop through temperatures and add them togheter
            for (int i = 0; i < temperature.Length; i++)
            {
                sum += temperature[i];
            }
            //foreach  (int i in temperature)
            //{
            //    sum += i;
            //}

            // temperature.lenght is the amount of items inside of theperature
            double average = sum / temperature.Length;

            return average;
        }
        //Method to find minimum temperature - same ase above temperature.Max();
        static int MinTemperature(int[] temperature)
        {
            int min = temperature[0];
            foreach  (int temp in temperature)
            {
                if (temp < min)
                {
                    min = temp;
                }
            }
            return min;
        }
       
    }
}

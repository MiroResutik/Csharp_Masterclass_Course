using System;

namespace DateTimeT
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //DateTime objects can be created using the DateTime constructor,
            //which takes parameters for year, month, day, and optionally hour, minute, second, and millisecond.
            DateTime dt1 = new DateTime(2026, 4, 24); // June 15, 2024
            

            

            Console.WriteLine($"My birthday is {dt1}");
            

            //Write today date
            Console.WriteLine($"\nToday is: {DateTime.Today}");
            //Write current date and time
            Console.WriteLine($"\nCurrent date and time: {DateTime.Now}");
            // Write tommorows date
            Console.WriteLine($"\nTommorow is: {DateTime.Today.AddDays(1)}");
            // Write day in 7 days
            Console.WriteLine($"\nDay in 7 days: {DateTime.Today.AddDays(7)}");
            //Write which day of the week we have now
            Console.WriteLine($"\nToday is: {DateTime.Today.DayOfWeek}");
            //Write fist day of the year
            Console.WriteLine($"\nFirst day of the year: {new DateTime(DateTime.Today.Year, 1, 1)}");
            //Write days in month
            Console.WriteLine($"\nDays in month: {DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)}");
            //Write day in month february 2000  
            Console.WriteLine($"\nDays in month February 2000: {DateTime.DaysInMonth(2000, 2)}");
            //Write the time in this structure: x o'clock y miutes and z seconds
            Console.WriteLine($"\nCurrent time: {DateTime.Now.Hour} o'clock {DateTime.Now.Minute} minutes and {DateTime.Now.Second} seconds");

            DateTime now = DateTime.Now;

            //Write the days passed since the user input their birthday
            Console.WriteLine("\n\nPlease enter your birthday (yyyy-mm-dd):");
            string input = Console.ReadLine();
            if(DateTime.TryParse(input, out DateTime birthday))
            {
                TimeSpan timeSpan = DateTime.Now - birthday;//Substruct the birthday from the current date to get the time span
                Console.WriteLine($"\nDays passed since: {timeSpan.Days} days");
            }
            else
            {
                Console.WriteLine("\nInvalid date format. Please enter the date in yyyy-mm-dd format!!!");
            }

        }
    }
}

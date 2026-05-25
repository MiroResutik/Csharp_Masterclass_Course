namespace EnumsC
{

    enum DayOfWeek
    {
        
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    //Index can be assigned to the first member of an enum, and the rest will be automatically assigned incrementally.
    //Index can be changed for any member, and the subsequent members will continue to increment from that point.
    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July = 12,
        August,
        September,
        October,
        November,
        December
    };  
    internal class Program
    {
        static void Main(string[] args)
        {
            DayOfWeek fr = DayOfWeek.Friday;
            DayOfWeek su = DayOfWeek.Sunday;

            DayOfWeek day = DayOfWeek.Monday;
            Console.WriteLine($"The value of {fr} is {(int)fr}");

            Console.WriteLine(DayOfWeek.Monday);
            Console.WriteLine((int)Month.January);
            Console.WriteLine((int)Month.August);

            // Math class
            Console.WriteLine("Ceiling: " + Math.Ceiling(15.3));
            Console.WriteLine("Floor: " + Math.Floor(15.3));

            // lower of two numbers
            Console.WriteLine("Min: " + Math.Min(15.3, 10.5));
            // higher of two numbers
            Console.WriteLine("Max: " + Math.Max(15.3, 10.5));

            // absolute value
            Console.WriteLine("Absolute Value: " + Math.Abs(-15.3));
            // power
            Console.WriteLine("Power: " + Math.Pow(15, 3));
            // square root
            Console.WriteLine("Square Root: " + Math.Sqrt(15));
            // round to nearest integer
            Console.WriteLine("Round: " + Math.Round(15.3));
            // round to nearest integer, away from zero
            Console.WriteLine("Round away from zero: " + Math.Round(15.3, MidpointRounding.AwayFromZero));
            // round to nearest integer, towards zero
            Console.WriteLine("Round towards zero: " + Math.Round(15.3, MidpointRounding.ToZero));
            // round to nearest integer, to even
            Console.WriteLine("Round to even: " + Math.Round(15.3, MidpointRounding.ToEven));
            // Write cosine of 45 degrees
            Console.WriteLine("Cosine of 45 degrees: " + Math.Cos(45 * Math.PI / 180));
            // Write sine of 45 degrees
            Console.WriteLine("Sine of 45 degrees: " + Math.Sin(45 * Math.PI / 180));
            // Write sine of 45 degrees rounded to 5 decimal places
            Console.WriteLine("Sine of 45 degrees rounded to 5 decimal places: " + Math.Round(Math.Sin(45 * Math.PI / 180), 5));

        }
    }
}

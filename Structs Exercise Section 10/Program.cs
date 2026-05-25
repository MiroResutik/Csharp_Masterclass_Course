using System;

namespace Structs_Exercise_Section_10
{
    // Define the Event struct with necessary fields and methods
    public struct Event
    {
        public DateTime StartDate;
        public DateTime EndDate;

        // Constructor to initialize the fields
        public Event(DateTime startDate, DateTime endDate)
        {
            // Throw an exception if the start date is not before the end date
            if (startDate >= endDate)
                throw new ArgumentException("StartDate must be before EndDate");

            StartDate = startDate;
            EndDate = endDate;
        }

        // Method to get the duration of the event in days
        public double GetDuration()
        {
            return (EndDate - StartDate).TotalDays;
        }

        // Method to check if this event overlaps with another event
        public bool IsOverlapping(Event otherEvent)
        {
            return StartDate < otherEvent.EndDate &&
                   EndDate > otherEvent.StartDate;
        }
    }

    // Exercise class
    public class Exercise
    {
        public static void TestEvents()
        {
            // Create two Event instances with different dates
            Event event1 = new Event(
                new DateTime(2024, 7, 1),
                new DateTime(2024, 7, 10)
            );

            Event event2 = new Event(
                new DateTime(2024, 7, 5),
                new DateTime(2024, 7, 15)
            );

            // Print the duration of each event
            Console.WriteLine($"Event 1 Duration: {event1.GetDuration()} days");
            Console.WriteLine($"Event 2 Duration: {event2.GetDuration()} days");

            // Check and print whether the events overlap
            Console.WriteLine($"Events Overlap: {event1.IsOverlapping(event2)}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise.TestEvents();
        }
    }
}
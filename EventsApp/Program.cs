using System.Runtime.CompilerServices;

namespace EventsApp
{
    // Delegates
    /*
    // Defining a delegate for event handling
    public delegate void Notify(string message);

    // Defining the Publisher class that raises events
    public class EventPublisher
    {
        // Event based on the Notify delegate
        public event Notify OnNotify; //On Notify is the event that subscribers can listen to
        // Method to trigger the event
        public void RaiseEvent(string message)
        {
            OnNotify?.Invoke(message); //Invoke the event if there are any subscribers
        }
    }

    //Event subscriber class that listens to the event
    public class EventSubscriber
    {

        public void OnEventReceived(string message)
        {
            Console.WriteLine($"Received message: {message}");
        }
    }
    */

    //Temperature monitor 

    // Delegate for temperature change events
    //public delegate void TemperatureChangedHandler(string message);

    // Custom EventArgs class for temperature change events (if needed for more complex data)
    public class TemperatureChangedEventArgs : EventArgs
    {
        public int NewTemperature { get; }
        public TemperatureChangedEventArgs(int newTemperature) // Constructor to initialize the new temperature
        {
            NewTemperature = newTemperature;
        }
    }
    // Temperature monitor class that raises
    // events when the temperature changes
    public class  TemperatureMonitor()
    {
        //public event TemperatureChangedHandler OnTemperatureChanged;

        //Using the generic delegate EventHandler<TEventArgs> to define the event
        // Using EventHandler with custom EventArgs for more detailed event data
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;
        private int _temperature;
        public int Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                //if (_temperature > 30)
                if (_temperature != value)
                {
                    //Raise the event when the temperature exceeds 30 degrees Celsius

                    //RaiseTEmperatureChanged($"Temperature changed above safe threshold! {_temperature}°C");
                    OnTemperatureChanged(new TemperatureChangedEventArgs(_temperature)); // Raise event with new temperature data

                }
            }
        }
        // Method to raise the temperature changed event
        //protected virtual void RaiseTEmperatureChanged(string message)
        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            //OnTemperatureChanged?.Invoke(message);
            // Letting every subscribe know about the temperature change and providing the new temperature data
            TemperatureChanged?.Invoke(this, e);
        }
    }
    // Subscriber class that listens to temperature change events
    public class TemperatureAlert
    {
        //public void OnTemperatureChanged(string message)
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            //Console.WriteLine($"ALERT: {message}");
            Console.WriteLine($"ALERT: temperature is {e.NewTemperature} and sender is: {sender}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the publisher and subscriber
            /*
            EventPublisher publisher = new EventPublisher(); // Create an instance of the event publisher
            EventSubscriber subscriber = new EventSubscriber(); // Create an instance of the event subscriber

            publisher.OnNotify += subscriber.OnEventReceived; // Subscribe to the event
            publisher.RaiseEvent("Raised Event....Hello, World!"); // Raise the event with a message
            */
            //Temperature monitor 

            TemperatureMonitor monitor = new TemperatureMonitor(); // Create an instance of the temperature monitor
            TemperatureAlert alert = new TemperatureAlert(); // Create an instance of the temperature alert subscriber
            //monitor.OnTemperatureChanged += alert.OnTemperatureChanged; // Subscribe to the temperature change event
            monitor.TemperatureChanged += alert.OnTemperatureChanged; // Subscribe to new event using EventHandler with custom EventArgs

            // Simulate temperature changes
            monitor.Temperature = 25; // Set temperature to 25°C (no alert)
            Console.WriteLine($"\nTemperature was {monitor.Temperature} before.");
            Console.WriteLine("\nPlease enter a current temperature: ");
            monitor.Temperature = int.Parse(Console.ReadLine()); // Set temperature to user input (potentially triggering an alert)


            Console.ReadKey(); // Wait for user input before closing the console
        }
    }
}

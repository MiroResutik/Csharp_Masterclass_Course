using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses
{
    internal class Logger
    {
        // Generic method without generic classes
        public void Log<T>(T message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}

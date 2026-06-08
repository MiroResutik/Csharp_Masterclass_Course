using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses
{
    internal class Comparer
    {
        // Set constrain for generic method
        public static bool AreEqual<T>(T first, T second) where T : class
        {
            return first == second;
        }
    }
}

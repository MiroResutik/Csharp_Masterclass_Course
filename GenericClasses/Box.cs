using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace GenericClasses
{

    // Single type parameter example
    /*
    internal class Box<T> // T is a type parameter, it can be any type
    {
        // The type parameter T allows us to create a box that can hold any type of content.
        /*
        public T Content { get; set; }

        public string Log()
        {
            return $"\nThe content of the box is: {Content}";
        }
        

        // To demonstrate a different use of the type parameter, let's create a method that updates the content of the box.

        private T content;
        public Box(T initialValue)
        {
            content = initialValue;
        }

        public void updateContent(T newContent)
        {
            content = newContent;
            Console.WriteLine($"Updated content to {content}");
        }

        public T GetContent()
        {
            return content;
        }
    }
    */

    // Multiple type parameter example
    /*
    internal class Box<TFirst, TSecond> // This class has two type parameters, allowing it to hold two different types of content.
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        public Box(TFirst first, TSecond second) 
        {
            First = first;
            Second = second;
        }
        public void Display()
        {
            Console.WriteLine($"\nThe first content of the box is: {First}\nThe second content of the box is: {Second}"); 
        }
    
    }
    */

    // Constraint for generic class 
    internal class Box<T> where T : class
    {

    }
}

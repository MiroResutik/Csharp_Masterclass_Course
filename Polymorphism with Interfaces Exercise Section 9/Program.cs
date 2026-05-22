using System;

namespace Polymorphism_with_Interfaces_Exercise_Section_9
{
    // Defining the IShape interface
    public interface IShape
    {
        double GetArea();
    }

    // Defining the Circle class that implements IShape
    public class Circle : IShape
    {
        private double radius;

        // Constructor to initialize the radius
        public Circle(double radius)
        {
            this.radius = radius;
        }

        // Implementation of GetArea for Circle
        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    // Defining the Rectangle class that implements IShape
    public class Rectangle : IShape
    {
        private double width;
        private double height;

        // Constructor to initialize width and height
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // Implementation of GetArea for Rectangle
        public double GetArea()
        {
            return width * height;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAreas();
        }

        // Method to print the areas of shapes
        public static void PrintAreas()
        {
            // Create an array of IShape objects
            IShape[] shapes = new IShape[]
            {
                new Circle(5),
                new Rectangle(4, 6)
            };

            // Iterate through each shape and print area
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area: {shape.GetArea()}");
            }
        }
    }
}
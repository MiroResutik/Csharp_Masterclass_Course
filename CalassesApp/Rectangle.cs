using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalassesApp
{
    internal class Rectangle
    {   // Declaration of the field - cosntant
        public const int NumberOfCorners = 4;
        // Declaration of the field
        public readonly string Color;

        //Initilise the constructor
        public Rectangle(string color)
        {
            Color = color;
        }

        // Method to dispaly the detail of the rectagle
        public void DispalyDetails()
        {
            Console.WriteLine($"Color: {Color}, Width: {Width}, Height: {Height}, Area: {Area}, Number of corners: {NumberOfCorners}");
        }

        public double Width { get; set; }
        public double Height { get; set; }

        //Computed property
        public double Area
        {
            get { return Width * Height; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalassesApp
{
    internal class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        //Computed property
        public double Area
        {
            get { return Width * Height; }
        }
    }
}

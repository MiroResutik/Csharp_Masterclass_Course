using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalassesApp
{
    internal class Car
    {
        //memeber variable
        //private hides the variable form other classes starts with _
        private string _model = "";
        private string _brand = "";
        private string _engine = "";
        private string _engineConfig = "";
        private bool _isLuxury;

        //Modifying getter and setter
        public string Brand
        {
            get 
            {
                if (IsLuxury)
                {
                    return _brand + " - Luxury Edition";
                }
                else
                {
                    {  return _brand; }
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("You enterd NOTHING!");
                    _brand = "DEFAULTVALUE";
                }
                else
                {
                    _brand = value;
                }
            }
        }
        
        //Getters and setters
        public bool IsLuxury { get => _isLuxury; set => _isLuxury = value; }
        public string Model { get => _model; set => _model = value; }
        public string Engine { get => _engine; set => _engine = value; }
        public string EngineConfig { get => _engineConfig; set => _engineConfig = value; }

        //Constructor - is called whenever creating an object of given class
        public Car(string model, string brand, string engine, string engineConfig, bool isLuxury)
        {
            Model = model;
            Brand = brand;
            Engine = engine;   
            EngineConfig = engineConfig;
            IsLuxury = isLuxury;


            Console.WriteLine("\n\nAn " + Brand + " of the model " + Model + " with engine " + Engine + " "+ EngineConfig+" has been created!");
            
        }
        //Not returning anything
        public void Drive()
        {
            Console.WriteLine($"\nThis is a Drive Method: I'm driving a {Brand} {Model} {Engine} {EngineConfig}");
        }
    }
}

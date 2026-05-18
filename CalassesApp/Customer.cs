using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalassesApp
{
    internal class Customer
    {
        //Static field to hold the next ID available
        private static int nextId = 0;

        // Unique identifier for customer
        private readonly int _id;

        // Read only property doesnt use set; and returns _id
        public int Id { get {return _id;} 
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        private string _password;
        //Write only property
        public string Password { set { _password = value; } } 

        //Default constructor
        public Customer()
        {
            // Increment id number by one
            _id = nextId++;
            Name = "DefaultName";
            Address = "Uknown";
            ContactNumber = "No Number";

        }

        //Custom constructor

        public Customer(string name, string address = "NotAplicaple", string contactNumber = "")
        {
            _id = nextId++;
            Name = name;
            Address = address;
            ContactNumber = contactNumber;

        }
        public void GetDetails()
        {
            Console.WriteLine($"Detail about the cutomer: Name is {Name} and ID is {_id}");
        }
        //public Customer(string name)
        //{
        //    Name = name;
        //}
        //Method - It can take Default Parameter in this case "NA"
        public void SetDetails(string name, string address, string contactNumber = "NA")
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;

        }
    }
}

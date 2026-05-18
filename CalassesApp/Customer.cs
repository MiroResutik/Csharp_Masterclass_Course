using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalassesApp
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        //Default constructor
        public Customer()
        {
            Name = "DefaultName";
            Address = "Uknown";
            ContactNumber = "No Number";

        }

        //Custom constructor

        public Customer(string name, string address = "NotAplicaple", string contactNumber = "")
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;

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

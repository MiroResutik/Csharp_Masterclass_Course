using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem
{
    internal class EmailTask : ITask<string>
    {

        public string Message { get; set; }
        public string Recipient { get; set; }

        public string Perform()
        {
            return $"\nEmail sent to {Recipient} with message {Message}";
        }
    }
}

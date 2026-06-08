using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem
{
    internal class ReportTask : ITask<string>
    {
        public string ReportName {  get; set; }

        public string Perform()
        {
            return $"\nReport Name: {ReportName} generated successfuly!!!";
        }
    }
}

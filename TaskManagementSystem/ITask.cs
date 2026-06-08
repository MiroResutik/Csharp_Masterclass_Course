using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem
{
    internal interface ITask<TResult>
    {
        TResult Perform();

    }
}

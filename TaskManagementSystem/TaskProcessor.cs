using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem
{
    internal class TaskProcessor<Ttask, TResult> where Ttask : ITask<TResult>
    {

        private Ttask task;

        public TaskProcessor(Ttask taskParam)
        {
            this.task = taskParam;
        }

        public TResult Execute()
        {
            return task.Perform();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.DMContract
{
    interface ITaskHandlerInterface
    {
        System.Threading.Tasks.Task AddTaskToDb(Task task);

    }
}

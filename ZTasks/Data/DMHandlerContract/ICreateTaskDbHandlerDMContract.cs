using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;

namespace ZTasks.Data.DMHandlerContract
{
    interface ICreateTaskDbHandlerDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask);

    }
}

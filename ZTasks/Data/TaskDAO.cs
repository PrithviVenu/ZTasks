using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.Models;

namespace ZTasks.Data
{
    class TaskDAO : ITaskHandler
    {


        Task ITaskHandler.AddTaskToDb(ZTask task)
        {
            throw new NotImplementedException();
        }
    }
}

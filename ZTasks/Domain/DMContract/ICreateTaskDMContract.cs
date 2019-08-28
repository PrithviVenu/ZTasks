using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;

namespace ZTasks.Domain.DMContract
{
    interface ICreateTaskDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskCallback callback)
;
    }
}

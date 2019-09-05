using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Utility;

namespace ZTasks.Domain.DMContract
{
    interface ICreateTaskDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskCallback callback, TaskOperation taskOperation)
;
    }
}

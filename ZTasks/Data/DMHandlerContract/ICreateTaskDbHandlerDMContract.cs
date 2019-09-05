using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Models;
using ZTasks.Utility;

namespace ZTasks.Data.DMHandlerContract
{
    interface ICreateTaskDbHandlerDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskDMCallback callback, TaskOperation taskOperation);

    }
}

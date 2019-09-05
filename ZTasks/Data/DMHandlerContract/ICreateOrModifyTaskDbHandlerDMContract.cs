using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Models;
using ZTasks.Utility;

namespace ZTasks.Data.DMHandlerContract
{
    interface ICreateOrModifyTaskDbHandlerDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateOrModifyTaskDMCallback callback, TaskOperation taskOperation);

    }
}

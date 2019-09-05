using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Utility;

namespace ZTasks.Domain.DMContract
{
    interface ICreateOrModifyTaskDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateOrModifyTaskCallback callback, TaskOperation taskOperation)
;
    }
}

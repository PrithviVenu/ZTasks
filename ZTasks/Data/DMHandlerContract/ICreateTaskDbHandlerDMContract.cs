using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Models;

namespace ZTasks.Data.DMHandlerContract
{
    interface ICreateTaskDbHandlerDMContract
    {
        Task AddTask(List<ZTask> task, ZTask parentZtask);

    }
}

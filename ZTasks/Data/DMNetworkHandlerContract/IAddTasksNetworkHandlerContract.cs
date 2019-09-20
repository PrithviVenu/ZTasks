using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.NetworkCallback;
using ZTasks.Models;

namespace ZTasks.Data.DMNetworkHandlerContract
{
   public interface IAddTasksNetworkHandlerContract
    {
        Task AddTasksAsync(IAddTasksNetworkCallback getTasksNetworkCallback, List<ZTask> task, ZTask parentZtask);
    }
}

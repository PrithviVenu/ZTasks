using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBack;

namespace ZTasks.Domain.DMContract
{
    interface ITaskHandler
    {
        Task AddTaskToDb(ObservableCollection<ZTask> task, ZTask parentZtask, IAddTasksDbCallback callback)
;
        Task GetTasksFromDb(IGetTasksDbCallback callback);
    }
}

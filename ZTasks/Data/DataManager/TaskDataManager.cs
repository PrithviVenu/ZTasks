using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBack;

namespace ZTasks.Data.DataManager
{
    class TaskDataManager : ITaskHandler
    {

        public DatabaseAccessContext zTasksContext;

        public TaskDataManager()
        {
            zTasksContext = new DatabaseAccessContext();

        }



        async Task ITaskHandler.AddTaskToDb(List<ZTask> task, ZTask parentZtask, IAddTasksDbCallback callback)
        {
            await DatabaseAccessContext.Connection.InsertAllAsync(task);
            await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
            callback.OnSuccess(true);
        }


        async Task ITaskHandler.GetTasksFromDb(IGetTasksDbCallback callback)
        {
            var Tasks = (await DatabaseAccessContext.Connection.QueryAsync<ZTask>("select * from ZTask"));
            callback.OnTasksFetchedSuccessfully((Tasks));
        }


    }
}

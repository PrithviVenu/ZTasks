using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.Models;
using ZTasks.Domain.UseCaseCallBack;

namespace ZTasks.Data
{
    class TaskDAO : ITaskHandler
    {

        public DatabaseAccessContext zTasksContext;

        public TaskDAO()
        {
            zTasksContext = new DatabaseAccessContext();

        }



        async Task ITaskHandler.AddTaskToDb(ObservableCollection<ZTask> task, ZTask parentZtask, IAddTasksDbCallback callback)
        {
            await DatabaseAccessContext.Connection.InsertAllAsync(task);
            await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
            callback.OnSuccess(true);
        }


        async Task ITaskHandler.GetTasksFromDb(IGetTasksDbCallback callback)
        {
            var Tasks = new ObservableCollection<ZTask>(await DatabaseAccessContext.Connection.QueryAsync<ZTask>("select * from ZTask"));
            callback.OnTasksFetchedSuccessfully((Tasks));
        }


    }
}

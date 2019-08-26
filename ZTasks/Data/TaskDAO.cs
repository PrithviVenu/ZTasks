using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.Models;

namespace ZTasks.Data
{
    class TaskDAO : ITaskHandler
    {

        public DatabaseAccessContext zTasksContext;

        public TaskDAO()
        {
            zTasksContext = new DatabaseAccessContext();

        }
        async Task ITaskHandler.AddTaskToDb(ObservableCollection<ZTask> task, ZTask parentZtask)
        {
            await DatabaseAccessContext.Connection.InsertAllAsync(task);
            await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
        }
    }
}

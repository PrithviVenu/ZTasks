using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandler
{
    class CreateTaskDbHandler : ICreateTaskDbHandlerDMContract
    {

        public DatabaseAccessContext zTasksContext;
        public ICreateTaskDMCallback callback;
        public CreateTaskDbHandler(ICreateTaskDMCallback callback)
        {
            zTasksContext = new DatabaseAccessContext();
            this.callback = callback;

        }
        async  public Task AddTask(List<ZTask> task, ZTask parentZtask)
        {
            await DatabaseAccessContext.Connection.InsertAllAsync(task);
            await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
            callback.OnSuccess(true);

        }

   
    }
}

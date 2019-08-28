using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;

namespace ZTasks.Data.DataManager
{
    class CreateTaskDataManager : ICreateTaskDMContract,ICreateTaskDMCallback
    {

        public DatabaseAccessContext zTasksContext;
        public ICreateTaskDbHandlerDMContract addTaskDbHandler;
        public ICreateTaskCallback callback;
        public CreateTaskDataManager()
        {
            zTasksContext = new DatabaseAccessContext();
        }



        async Task ICreateTaskDMContract.AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskCallback callback)
        {
            // var v1 = await DatabaseAccessContext.Connection.InsertAllAsync(task);
            //var v= await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
            this.callback = callback;
            addTaskDbHandler = new CreateTaskDbHandler(this);
            await addTaskDbHandler.AddTask(task, parentZtask);
        }
        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }


     


    }
}

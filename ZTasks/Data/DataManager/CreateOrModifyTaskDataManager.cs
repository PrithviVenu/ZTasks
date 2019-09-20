using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Utility;
using ZTasks.Data.NetworkCallback;
using ZTasks.Data.NetworkHandler;
using ZTasks.Data.DMNetworkHandlerContract;

namespace ZTasks.Data.DataManager
{
    class CreateOrModifyTaskDataManager : ICreateOrModifyTaskDMContract, ICreateOrModifyTaskDMCallback, IAddTasksNetworkCallback
    {

        public ICreateOrModifyTaskDbHandlerDMContract addTaskDbHandler;
        public ICreateOrModifyTaskCallback callback;



        async Task ICreateOrModifyTaskDMContract.AddOrModifyTask(List<ZTask> task, ZTask parentZtask, ICreateOrModifyTaskCallback callback, TaskOperation taskOperation)
        {
            this.callback = callback;
            addTaskDbHandler = CreateOrModifyTaskDbHandler.GetInstance;
            if (taskOperation == TaskOperation.Add)
            {
                IAddTasksNetworkHandlerContract Handler = new CreateOrModifyTaskNetworkHandler();
                await Handler.AddTasksAsync(this, task, parentZtask);
            }
            //  await addTaskDbHandler.AddOrModifyTask(task, parentZtask, this, taskOperation);
        }
        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }

        public void OnSuccess(ZTask task)
        {

        }

        public void OnFailure()
        {
        }
    }
}

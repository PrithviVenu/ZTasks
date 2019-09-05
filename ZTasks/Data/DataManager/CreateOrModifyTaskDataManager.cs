using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Utility;

namespace ZTasks.Data.DataManager
{
    class CreateOrModifyTaskDataManager : ICreateOrModifyTaskDMContract, ICreateOrModifyTaskDMCallback
    {

        public ICreateOrModifyTaskDbHandlerDMContract addTaskDbHandler;
        public ICreateOrModifyTaskCallback callback;



        async Task ICreateOrModifyTaskDMContract.AddOrModifyTask(List<ZTask> task, ZTask parentZtask, ICreateOrModifyTaskCallback callback, TaskOperation taskOperation)
        {
            this.callback = callback;
            addTaskDbHandler = CreateOrModifyTaskDbHandler.GetInstance;
            await addTaskDbHandler.AddOrModifyTask(task, parentZtask, this, taskOperation);
        }
        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }





    }
}

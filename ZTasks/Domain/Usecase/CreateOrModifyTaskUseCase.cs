using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DataManager;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Presentation.PresenterCallBackHandler;
using ZTasks.Utility;

namespace ZTasks.Domain.Usecase
{
    class CreateOrModifyTaskUseCase : UseCaseBase, ICreateOrModifyTaskCallback
    {
        public List<ZTask> tasks;
        public ZTask parentZtask;
        public ICreateOrModifyTaskPresenterCallback callback;
        public TaskOperation taskOperation;
        public CreateOrModifyTaskUseCase(List<ZTask> tasks, ZTask parentZtask, ICreateOrModifyTaskPresenterCallback callBack, TaskOperation taskOperation)
        {
            this.tasks = tasks;
            this.parentZtask = parentZtask;
            this.callback = callBack;
            this.taskOperation = taskOperation;

        }


        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }

        protected override async Task ActionAsync()
        {
            ICreateOrModifyTaskDMContract taskHandler = new CreateOrModifyTaskDataManager();


            await taskHandler.AddOrModifyTask(tasks, parentZtask, this, taskOperation);

        }
    }
}

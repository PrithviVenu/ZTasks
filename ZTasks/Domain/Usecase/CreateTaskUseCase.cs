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
    class CreateTaskUseCase : UseCaseBase, ICreateTaskCallback
    {
        public List<ZTask> tasks;
        public ZTask parentZtask;
        public ICreateTaskPresenterCallback callback;
        public TaskOperation taskOperation;
        public CreateTaskUseCase(List<ZTask> tasks, ZTask parentZtask, ICreateTaskPresenterCallback callBack, TaskOperation taskOperation)
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
            ICreateTaskDMContract taskHandler = new CreateTaskDataManager();


            await taskHandler.AddTask(tasks, parentZtask, this, taskOperation);

        }
    }
}

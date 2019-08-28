using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DataManager;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Presentation.PresenterCallBackHandler;

namespace ZTasks.Domain.Usecase
{
    class CreateTaskUseCase : UseCaseBase, ICreateTaskCallback
    {
        public List<ZTask> tasks;
        public ZTask parentZtask;
        public ICreateTaskPresenterCallback callback;

        public CreateTaskUseCase(List<ZTask> tasks, ZTask parentZtask, ICreateTaskPresenterCallback callBack)
        {
            this.tasks = tasks;
            this.parentZtask = parentZtask;
            this.callback = callBack;
        }
       

        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }

        protected override async Task ActionAsync()
        {
            ICreateTaskDMContract taskHandler = new CreateTaskDataManager();


            await taskHandler.AddTask(tasks, parentZtask, this);

        }
    }
}

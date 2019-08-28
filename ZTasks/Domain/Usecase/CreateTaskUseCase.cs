using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DataManager;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBack;
using ZTasks.Presentation.PresenterCallBack;

namespace ZTasks.Domain.Usecase
{
    class CreateTaskUseCase : UseCaseBase, IAddTasksDbCallback
    {
        public List<ZTask> tasks;
        public ZTask parentZtask;
        public IAddTaskCallback callback;

        public CreateTaskUseCase(List<ZTask> tasks, ZTask parentZtask, IAddTaskCallback callBack)
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
            ITaskHandler taskHandler = new TaskDataManager();


            await taskHandler.AddTaskToDb(tasks, parentZtask, this);

        }
    }
}

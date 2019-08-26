using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.Models;

namespace ZTasks.Domain.Usecase
{
    class CreateTaskUseCase : UseCaseBase
    {
        public ObservableCollection<ZTask> tasks;
        public ZTask parentZtask;

        public CreateTaskUseCase(ObservableCollection<ZTask> tasks, ZTask parentZtask)
        {
            this.tasks = tasks;
            this.parentZtask = parentZtask;
        }
        public async override void Execute()
        {
            if (GetIfAvailableInCache())
            {
                return;
            }

            await ActionAsync();
        }

        protected override async Task ActionAsync()
        {
            ITaskHandler taskHandler = new TaskDAO();


            await taskHandler.AddTaskToDb(tasks, parentZtask);

        }
    }
}

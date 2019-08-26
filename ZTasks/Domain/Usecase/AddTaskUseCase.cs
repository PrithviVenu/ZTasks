using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.Models;

namespace ZTasks.Domain.Usecase
{
    class AddTaskUseCase : UseCaseBase
    {
        public ObservableCollection<ZTask> tasks;

        public AddTaskUseCase(ObservableCollection<ZTask> tasks)
        {
            this.tasks = tasks;
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
            await ActionAsync();
        }
    }
}

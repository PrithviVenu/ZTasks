using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBack;
using ZTasks.Presentation.PresenterCallBack;
namespace ZTasks.Domain.Usecase
{
    class GetTasksUseCase : UseCaseBase, IGetTasksDbCallback
    {
        public ObservableCollection<ZTask> tasks;
        public IGetTasksCallBack callback;

        public GetTasksUseCase(IGetTasksCallBack callback)
        {
            this.callback = callback;
        }

        public async override void Execute()
        {
            if (GetIfAvailableInCache())
            {
                return;
            }

            await Task.Run(async () => await  ActionAsync());
        }

        public void OnTasksFetchedSuccessfully(ObservableCollection<ZTask> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully(ZtaskList);
        }

        protected override async Task ActionAsync()
        {
            ITaskHandler taskHandler = new TaskDAO();
            await taskHandler.GetTasksFromDb(this);


            //ObservableCollection<ZTask> await taskHandler.GetTasksFromDb();

        }
    }
}

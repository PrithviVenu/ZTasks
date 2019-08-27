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
using System.Diagnostics;

namespace ZTasks.Domain.Usecase
{
    class GetTasksUseCase : UseCaseBase, IGetTasksDbCallback
    {
        public IGetTasksCallBack callback;

        public GetTasksUseCase(IGetTasksCallBack callback)
        {
            this.callback = callback;
        }

      

        public void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
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

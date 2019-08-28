using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DataManager;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Presentation.PresenterCallBackHandler;

namespace ZTasks.Domain.Usecase
{
    class GetTaskUseCase : UseCaseBase, IGetTaskCallback
    {
        public IGetTaskPresenterCallBack callback;

        public GetTaskUseCase(IGetTaskPresenterCallBack callback)
        {
            this.callback = callback;
        }

      

        public void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully(ZtaskList);
        }

        protected override async Task ActionAsync()
        {
            IGetTaskDMContract taskHandler = new GetTaskDataManager();
            await taskHandler.GetTasks(this);


            //ObservableCollection<ZTask> await taskHandler.GetTasksFromDb();

        }
    }
}

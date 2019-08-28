using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Models;

namespace ZTasks.Data.DataManager
{
    class GetTaskDataManager : IGetTaskDMContract, IGetTaskDMCallback
    {
        public DatabaseAccessContext zTasksContext;
        public IGetTaskCallback callback;
        public GetTaskDbHandler getTaskDbHandler;

        public GetTaskDataManager()
        {
            zTasksContext = new DatabaseAccessContext();

        }
        async public Task GetTasks(IGetTaskCallback callback)
        {
            this.callback = callback;
            getTaskDbHandler = new GetTaskDbHandler(this);
            await getTaskDbHandler.GetTasks();
        }

        public void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully((ZtaskList));
        }
    }
}

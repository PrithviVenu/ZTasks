using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Models;
using ZTasks.Utility;

namespace ZTasks.Data.DataManager
{
    class GetTaskDataManager : IGetTaskDMContract, IGetTaskDMCallback
    {
        public IGetTaskCallback callback;
        public GetTaskDbHandler getTaskDbHandler;


        async public Task GetTasks(IGetTaskCallback callback, TaskView taskView)
        {
            this.callback = callback;
            getTaskDbHandler = GetTaskDbHandler.GetInstance;
            await getTaskDbHandler.GetTasks(this,taskView);
        }

        public void OnTasksFetchedSuccessfully(List<TaskUtilityModel> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully((ZtaskList));
        }
    }
}

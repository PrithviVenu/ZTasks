using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Data.DMNetworkHandlerContract;
using ZTasks.Data.NetworkCallback;
using ZTasks.Data.NetworkHandler;
using ZTasks.Domain.DMContract;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Models;
using ZTasks.Utility;

namespace ZTasks.Data.DataManager
{
    class GetTaskDataManager : IGetTaskDMContract, IGetTaskDMCallback, IGetTasksNetworkCallback
    {
        public IGetTaskCallback callback;
        public GetTaskDbHandler getTaskDbHandler;

        async public Task GetTasks(IGetTaskCallback callback, TaskView taskView)
        {
            this.callback = callback;
            getTaskDbHandler = GetTaskDbHandler.GetInstance;
            await getTaskDbHandler.GetTasks(this, taskView);
            IGetTaskNetworkHandlerContract getTaskNetworkHandler = new GetTaskNetworkHandler();
            await getTaskNetworkHandler.GetTasksAsync(this);
            this.callback = callback;
            getTaskDbHandler = GetTaskDbHandler.GetInstance;
            await getTaskDbHandler.GetTasks(this, taskView);
        }

        public void OnTasksFetchedSuccessfully(List<TaskUtilityModel> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully((ZtaskList));
        }
        public async Task OnNetworkSyncSuccessful(List<TaskUtilityModel> ZtaskList)
        {
            IAddTasksDBHandlerContract handler = AddTasksDBHandler.GetInstance;
            await handler.AddOrModifyTasks(ZtaskList);

        }

    }
}

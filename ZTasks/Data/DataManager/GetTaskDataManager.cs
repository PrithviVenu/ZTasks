﻿using System.Collections.Generic;
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
        public IGetTaskCallback callback;
        public GetTaskDbHandler getTaskDbHandler;

   
        async public Task GetTasks(IGetTaskCallback callback)
        {
            this.callback = callback;
            getTaskDbHandler =  GetTaskDbHandler.GetInstance;
            await getTaskDbHandler.GetTasks(this);
        }

        public void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully((ZtaskList));
        }
    }
}

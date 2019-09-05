﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Data.DatabaseHandler;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Utility;

namespace ZTasks.Data.DataManager
{
    class CreateTaskDataManager : ICreateTaskDMContract, ICreateTaskDMCallback
    {

        public ICreateTaskDbHandlerDMContract addTaskDbHandler;
        public ICreateTaskCallback callback;



        async Task ICreateTaskDMContract.AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskCallback callback, TaskOperation taskOperation)
        {
            this.callback = callback;
            addTaskDbHandler = CreateTaskDbHandler.GetInstance;
            await addTaskDbHandler.AddTask(task, parentZtask, this, taskOperation);
        }
        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }





    }
}

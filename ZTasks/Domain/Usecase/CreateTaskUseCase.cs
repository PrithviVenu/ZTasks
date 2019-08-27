﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    class CreateTaskUseCase : UseCaseBase, IAddTasksDbCallback
    {
        public ObservableCollection<ZTask> tasks;
        public ZTask parentZtask;
        public IAddTaskCallback callback;

        public CreateTaskUseCase(ObservableCollection<ZTask> tasks, ZTask parentZtask, IAddTaskCallback callBack)
        {
            this.tasks = tasks;
            this.parentZtask = parentZtask;
            this.callback = callBack;
        }
        public async override void Execute()
        {
            if (GetIfAvailableInCache())
            {
                return;
            }

            await ActionAsync();
        }

        public void OnSuccess(bool success)
        {
            callback.OnSuccess(success);
        }

        protected override async Task ActionAsync()
        {
            ITaskHandler taskHandler = new TaskDAO();


            await taskHandler.AddTaskToDb(tasks, parentZtask, this);

        }
    }
}

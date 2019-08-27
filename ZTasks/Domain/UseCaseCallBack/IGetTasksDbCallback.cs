﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.Models;

namespace ZTasks.Domain.UseCaseCallBack
{
    interface IGetTasksDbCallback
    {
        void OnTasksFetchedSuccessfully(ObservableCollection<ZTask> ZtaskList);

    }
}

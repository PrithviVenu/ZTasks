using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;

namespace ZTasks.Presentation.PresenterCallBack
{
    interface IGetTasksCallBack
    {
        void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList);
    }
}

using System.Collections.Generic;
using ZTasks.Models;

namespace ZTasks.Presentation.PresenterCallBackHandler
{
    interface IGetTaskPresenterCallBack
    {
        void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList);
    }
}

using System.Collections.Generic;
using ZTasks.Models;

namespace ZTasks.Domain.UseCaseCallBackHandler
{
    interface IGetTaskCallback
    {
        void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList);

    }
}

using System.Collections.Generic;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandlerCallback
{
    interface IGetTaskDMCallback
    {
        void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList);

    }
}



using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandlerCallback
{
    interface ICreateOrModifyTaskDMCallback
    {
        void OnSuccess(ZTask task);

    }
}

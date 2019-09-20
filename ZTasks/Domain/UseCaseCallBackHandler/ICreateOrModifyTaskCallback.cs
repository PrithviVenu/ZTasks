

using ZTasks.Models;

namespace ZTasks.Domain.UseCaseCallBackHandler
{
    interface ICreateOrModifyTaskCallback
    {
        void OnSuccess(ZTask task);

    }
}

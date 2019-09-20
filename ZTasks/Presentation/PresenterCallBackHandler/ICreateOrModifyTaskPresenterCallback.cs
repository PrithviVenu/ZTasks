

using ZTasks.Models;

namespace ZTasks.Presentation.PresenterCallBackHandler
{
    interface ICreateOrModifyTaskPresenterCallback
    {
        void OnSuccess(ZTask task);

    }
}

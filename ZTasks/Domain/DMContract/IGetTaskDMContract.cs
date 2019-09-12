using System.Threading.Tasks;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Utility;

namespace ZTasks.Domain.DMContract
{
    interface IGetTaskDMContract
    {
        Task GetTasks(IGetTaskCallback callback, TaskView taskView);

    }
}

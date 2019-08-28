using System.Threading.Tasks;
using ZTasks.Domain.UseCaseCallBackHandler;

namespace ZTasks.Domain.DMContract
{
    interface IGetTaskDMContract
    {
        Task GetTasks(IGetTaskCallback callback);

    }
}

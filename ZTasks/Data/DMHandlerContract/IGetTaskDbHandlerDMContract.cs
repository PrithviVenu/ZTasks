using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Utility;

namespace ZTasks.Data.DMHandlerContract
{
    interface IGetTaskDbHandlerDMContract
    {
          Task GetTasks(IGetTaskDMCallback callback, TaskView taskView);

    }
}

using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;

namespace ZTasks.Data.DMHandlerContract
{
    interface IGetTaskDbHandlerDMContract
    {
          Task GetTasks(IGetTaskDMCallback callback);

    }
}

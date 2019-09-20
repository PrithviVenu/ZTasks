using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;

namespace ZTasks.Data.NetworkCallback
{
    public interface IAddTasksNetworkCallback
    {
        void OnSuccess(ZTask task);
        void OnFailure();

    }
}

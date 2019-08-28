using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Data.DatabaseHandlerCallback
{
    interface ICreateTaskDMCallback
    {
        void OnSuccess(bool success);

    }
}

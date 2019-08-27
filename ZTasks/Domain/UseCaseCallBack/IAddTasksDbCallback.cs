using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.UseCaseCallBack
{
    interface IAddTasksDbCallback
    {
        void OnSuccess(bool success);

    }
}

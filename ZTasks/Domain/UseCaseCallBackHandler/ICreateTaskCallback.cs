using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.UseCaseCallBackHandler
{
    interface ICreateTaskCallback
    {
        void OnSuccess(bool success);

    }
}

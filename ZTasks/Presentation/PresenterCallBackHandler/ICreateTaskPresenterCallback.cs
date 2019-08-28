using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Presentation.PresenterCallBackHandler
{
    interface ICreateTaskPresenterCallback
    {
        void OnSuccess(bool success);

    }
}

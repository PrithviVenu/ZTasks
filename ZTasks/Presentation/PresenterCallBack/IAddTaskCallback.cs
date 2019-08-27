using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Presentation.PresenterCallBack
{
    interface IAddTaskCallback
    {
        void OnSuccess(bool success);

    }
}

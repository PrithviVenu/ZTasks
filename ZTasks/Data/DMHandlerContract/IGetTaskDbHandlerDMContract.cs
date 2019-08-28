using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;

namespace ZTasks.Data.DMHandlerContract
{
    interface IGetTaskDbHandlerDMContract
    {
          Task GetTasks();

    }
}

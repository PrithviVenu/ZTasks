using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandler
{
    class GetTaskDbHandler: IGetTaskDbHandlerDMContract
    {

        public IGetTaskDMCallback callback;
        public GetTaskDbHandler(IGetTaskDMCallback callback)
        {
            this.callback = callback;
        }

        async public Task GetTasks()
        {
            var Tasks = (await DatabaseAccessContext.Connection.QueryAsync<ZTask>("select * from ZTask"));
            callback.OnTasksFetchedSuccessfully((Tasks));
        }
    }
}

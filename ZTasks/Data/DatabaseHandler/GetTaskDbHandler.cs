using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandler
{
    class GetTaskDbHandler: IGetTaskDbHandlerDMContract
    {
        public DatabaseAccessContext zTasksContext;
        private static GetTaskDbHandler instance = null;
        private static readonly object lockobj = new object();
        private GetTaskDbHandler()
        {
            zTasksContext =  DatabaseAccessContext.GetInstance;
        }
        public static GetTaskDbHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        if (instance == null)
                            instance = new GetTaskDbHandler();
                    }
                }
                return instance;
            }
        }

        async public Task GetTasks(IGetTaskDMCallback callback)
        {
            var Tasks = (await DatabaseAccessContext.Connection.QueryAsync<ZTask>("select * from ZTask"));
            callback.OnTasksFetchedSuccessfully((Tasks));
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandler
{
    class CreateTaskDbHandler : ICreateTaskDbHandlerDMContract
    {

        public DatabaseAccessContext zTasksContext;
        private static CreateTaskDbHandler instance = null;
        private static readonly object lockobj = new object();
        private CreateTaskDbHandler()
        {
            zTasksContext = DatabaseAccessContext.GetInstance;

        }
        public static CreateTaskDbHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        if (instance == null)
                            instance = new CreateTaskDbHandler();
                    }
                }
                return instance;
            }
        }
        async  public Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskDMCallback callback)
        {
            await DatabaseAccessContext.Connection.InsertAllAsync(task);
            await DatabaseAccessContext.Connection.InsertAsync(parentZtask);
            callback.OnSuccess(true);

        }

   
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;
using ZTasks.Utility;

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
        async public Task AddTask(List<ZTask> task, ZTask parentZtask, ICreateTaskDMCallback callback, TaskOperation taskOperation)
        {
            await AddOrModifyTasks(task, taskOperation);

            if (taskOperation == TaskOperation.Add)
            {
                await DatabaseAccessContext.Connection.InsertAsync(parentZtask.TaskDetails);
                await DatabaseAccessContext.Connection.InsertAsync(parentZtask.Assignment);
            }
            else if (taskOperation == TaskOperation.Modify)
            {
                await DatabaseAccessContext.Connection.UpdateAsync(parentZtask.TaskDetails);
                await DatabaseAccessContext.Connection.UpdateAsync(parentZtask.Assignment);

            }
            callback.OnSuccess(true);

        }

        async public Task AddOrModifyTasks(List<ZTask> task, TaskOperation taskOperation)
        {
            foreach (ZTask zTask in task)
            {

                if (taskOperation == TaskOperation.Add)
                {
                    await DatabaseAccessContext.Connection.InsertAsync(zTask.TaskDetails);
                    await DatabaseAccessContext.Connection.InsertAsync(zTask.Assignment);
                }
                else if (taskOperation == TaskOperation.Modify)
                {
                    int rowsAffectedTaskDetails = await DatabaseAccessContext.Connection.UpdateAsync(zTask.TaskDetails);
                    int rowsAffectedAssignment = await DatabaseAccessContext.Connection.UpdateAsync(zTask.Assignment);
                    Debug.WriteLine(rowsAffectedAssignment);
                    Debug.WriteLine(rowsAffectedTaskDetails);

                    if (rowsAffectedAssignment <= 0)
                    {
                        await DatabaseAccessContext.Connection.InsertAsync(zTask.Assignment);
                    }
                    if (rowsAffectedTaskDetails <= 0)
                    {
                        await DatabaseAccessContext.Connection.InsertAsync(zTask.TaskDetails);
                    }
                }

            }
        }

    }
}

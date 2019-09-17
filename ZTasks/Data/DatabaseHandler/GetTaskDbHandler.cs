using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ZTasks.Data.DatabaseHandlerCallback;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;
using ZTasks.Utility;
namespace ZTasks.Data.DatabaseHandler
{
    class GetTaskDbHandler : IGetTaskDbHandlerDMContract
    {
        public DatabaseAccessContext zTasksContext;
        private static GetTaskDbHandler instance = null;
        private static readonly object lockobj = new object();
        private GetTaskDbHandler()
        {

            zTasksContext = DatabaseAccessContext.GetInstance;
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

        async public Task GetTasks(IGetTaskDMCallback callback, TaskView taskView)
        {
            string query = "";
            List<TaskUtilityModel> Tasks = new List<TaskUtilityModel>();
            Debug.WriteLine(((DateTimeOffset)DateTimeOffset.Now.Date).ToUnixTimeMilliseconds(), "todayyy");
            switch (taskView)
            {
                case TaskView.Home:
                    query = "select TaskDetail.* , TaskAssignment.* from TaskDetail inner join TaskAssignment where TaskDetail.TaskId = TaskAssignment.TaskId ";
                    Tasks = await DatabaseAccessContext.Connection.QueryAsync<TaskUtilityModel>(query);
                    break;
                case TaskView.Today:
                    query = "select TaskDetail.* , TaskAssignment.* from TaskDetail inner join TaskAssignment where TaskDetail.TaskId = TaskAssignment.TaskId AND TaskDetail.DueDate NOT NULL AND TaskStatus = 0 AND TaskDetail.DueDate = ?";
                    Tasks = await DatabaseAccessContext.Connection.QueryAsync<TaskUtilityModel>(query, DateTime.Now.Date);
                    break;
                case TaskView.Upcoming:
                    query = "select TaskDetail.* , TaskAssignment.* from TaskDetail inner join TaskAssignment where TaskDetail.TaskId = TaskAssignment.TaskId AND TaskDetail.DueDate NOT NULL AND TaskStatus = 0 AND TaskDetail.DueDate > ?";
                    Tasks = await DatabaseAccessContext.Connection.QueryAsync<TaskUtilityModel>(query, DateTime.Now.Date);
                    break;
                case TaskView.Delayed:
                    query = "select TaskDetail.* , TaskAssignment.* from TaskDetail inner join TaskAssignment where TaskDetail.TaskId = TaskAssignment.TaskId AND TaskDetail.DueDate NOT NULL AND TaskStatus = 0 AND TaskDetail.DueDate < ?";
                    Tasks = await DatabaseAccessContext.Connection.QueryAsync<TaskUtilityModel>(query, DateTime.Now.Date);
                    break;
                case TaskView.AssignedToOthers:
                    query = "select TaskDetail.* , TaskAssignment.* from TaskDetail inner join TaskAssignment where TaskDetail.TaskId = TaskAssignment.TaskId AND AssignedById = 'user101010' AND AssigneeId != 'user101010' ";
                    Tasks = await DatabaseAccessContext.Connection.QueryAsync<TaskUtilityModel>(query, DateTime.Now.Date);
                    break;
            }

            // Debug.WriteLine(Tasks.Count, "countuuuuuuuuuuu");

            foreach (TaskUtilityModel zTask in Tasks)
            {
                Debug.WriteLine(zTask.DueDate, "countuuuuuuuuuuu");
                //Debug.WriteLine(zTask, "lol");
                //    if (zTask.ParentTaskId == null)
                //    {
                //        Debug.WriteLine(zTask.ParentTaskId, zTask.TaskTitle);

                //    }
                //    else
                //    {
                //        Debug.WriteLine(zTask.ParentTaskId, "ooo");
                //    }
            }

            callback.OnTasksFetchedSuccessfully(Tasks);
        }
    }


}

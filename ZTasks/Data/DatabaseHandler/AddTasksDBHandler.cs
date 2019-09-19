using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data.DMHandlerContract;
using ZTasks.Models;

namespace ZTasks.Data.DatabaseHandler
{
    public class AddTasksDBHandler : IAddTasksDBHandlerContract
    {
        public DatabaseAccessContext zTasksContext;
        private static AddTasksDBHandler instance = null;
        private static readonly object lockobj = new object();
        private AddTasksDBHandler()
        {
            zTasksContext = DatabaseAccessContext.GetInstance;

        }
        public static AddTasksDBHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        if (instance == null)
                            instance = new AddTasksDBHandler();
                    }
                }
                return instance;
            }
        }
        async public Task AddOrModifyTasks(List<TaskUtilityModel> utility)
        {
            List<ZTask> task = TaskUtilityToZTask(utility);
            foreach (ZTask zTask in task)
            {
                if (string.IsNullOrWhiteSpace(zTask.Assignment.AssigneeName))
                {
                    zTask.Assignment.AssigneeName = "Prithvi Venu";
                }
                if (string.IsNullOrWhiteSpace(zTask.Assignment.AssignedByName))
                {
                    zTask.Assignment.AssignedByName = "Prithvi Venu";
                }

                var rows = await DatabaseAccessContext.Connection.UpdateAsync(zTask.TaskDetails);
                await DatabaseAccessContext.Connection.UpdateAsync(zTask.Assignment);

                if (rows <= 0)
                {
                    await DatabaseAccessContext.Connection.InsertAsync(zTask.TaskDetails);
                    await DatabaseAccessContext.Connection.InsertAsync(zTask.Assignment);
                }
            }



        }
        public List<ZTask> TaskUtilityToZTask(List<TaskUtilityModel> ZtaskList)
        {
            List<ZTask> tasks = new List<ZTask>();
            List<ZTask> subTasks = new List<ZTask>();

            foreach (TaskUtilityModel task in ZtaskList)
            {

                ZTask zTask = new ZTask();
                TaskDetail taskDetail = zTask.TaskDetails;
                TaskAssignment taskAssignment = zTask.Assignment;
                taskDetail.TaskId = task.TaskId; taskDetail.TaskTitle = task.TaskTitle; taskDetail.CreatedTime = task.CreatedTime; taskDetail.DueDate = task.DueDate; taskDetail.ModifiedDate = task.ModifiedDate; taskDetail.Priority = task.Priority; taskDetail.TaskStatus = task.TaskStatus; taskDetail.RemindOn = task.RemindOn; taskDetail.Description = task.Description; taskDetail.ParentTaskId = task.ParentTaskId;
                taskAssignment.TaskId = taskDetail.TaskId; taskAssignment.AssigneeId = task.AssigneeId; taskAssignment.AssignedById = task.AssignedById; taskAssignment.AssignedByName = task.AssignedByName; taskAssignment.AssigneeName = task.AssigneeName;
                if (zTask.TaskDetails.ParentTaskId == null)
                {
                    tasks.Add(zTask);
                }
                else
                {
                    subTasks.Add(zTask);
                }

            }
            foreach (ZTask task in tasks)
            {
                foreach (ZTask subTask in subTasks)
                {
                    if (subTask.TaskDetails.ParentTaskId == task.TaskDetails.TaskId)
                    {
                        task.SubTasks.Add(subTask);
                    }
                }
            }
            return tasks;

        }
    }
}

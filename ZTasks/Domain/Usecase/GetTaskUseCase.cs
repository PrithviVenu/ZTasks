using System.Collections.Generic;
using System.Threading.Tasks;
using ZTasks.Data.DataManager;
using ZTasks.Domain.DMContract;
using ZTasks.Models;
using ZTasks.Domain.UseCaseCallBackHandler;
using ZTasks.Presentation.PresenterCallBackHandler;
using System.Diagnostics;
using ZTasks.Utility;

namespace ZTasks.Domain.Usecase
{
    class GetTaskUseCase : UseCaseBase, IGetTaskCallback
    {
        public IGetTaskPresenterCallBack callback;
        public TaskView taskView;
        public GetTaskUseCase(IGetTaskPresenterCallBack callback, TaskView taskView)
        {
            this.callback = callback;
            this.taskView = taskView;
        }



        public void OnTasksFetchedSuccessfully(List<TaskUtilityModel> ZtaskList)
        {
            callback.OnTasksFetchedSuccessfully(TaskUtilityToZTask(ZtaskList));
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

        protected override async Task ActionAsync()
        {

            IGetTaskDMContract taskHandler = new GetTaskDataManager();
            await taskHandler.GetTasks(this, taskView);


            //ObservableCollection<ZTask> await taskHandler.GetTasksFromDb();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZTasks.Data.DMNetworkHandlerContract;
using ZTasks.Data.NetworkCallback;
using ZTasks.Models;

namespace ZTasks.Data.NetworkHandler
{
    public class CreateOrModifyTaskNetworkHandler : IAddTasksNetworkHandlerContract
    {
        public async Task AddTasksAsync(IAddTasksNetworkCallback addTasksNetworkCallback, List<ZTask> task, ZTask parentZtask)
        {
            await NetworkHelper.InitializeClientAsync();

            var parameters = new Dictionary<string, string>
            {
                { "taction", "addTaskSubtask" },
                { "title",parentZtask.TaskDetails.TaskTitle},
                {"priority",parentZtask.TaskDetails.Priority.ToString() },
                {"status", parentZtask.TaskDetails.TaskStatus.ToString()}
            };
            if (parentZtask.TaskDetails.DueDate != null)
            {
                string fmt = "d";
                parameters.Add("dueDate", parentZtask.TaskDetails.DueDate.Value.DateTime.Date.ToString(fmt));
            }
            if (parentZtask.TaskDetails.RemindOn != null)
            {
                string fmt = "MM/dd/yyyy HH:mm:ss";
                parameters.Add("reminderDate", parentZtask.TaskDetails.RemindOn.Value.DateTime.ToString(fmt));
            }
            if (!string.IsNullOrEmpty(parentZtask.TaskDetails.Description))
            {
                parameters.Add("summary", parentZtask.TaskDetails.Description);
            }


            var encodedContent = new FormUrlEncodedContent(parameters);
            CancellationTokenSource cts = new CancellationTokenSource(30000);
            CancellationToken cancellationToken = cts.Token;
            HttpResponseMessage response = await NetworkHelper.Client.PostAsync("/zm/taskActionAPI.do", encodedContent, cancellationToken);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ZTask zTask = new ZTask();
                zTask.TaskDetails.TaskTitle = parentZtask.TaskDetails.TaskTitle;
                zTask.Assignment.AssigneeName = parentZtask.Assignment.AssigneeName;

                addTasksNetworkCallback.OnSuccess(zTask);
            }
            Debug.WriteLine(result);
        }

    }
}

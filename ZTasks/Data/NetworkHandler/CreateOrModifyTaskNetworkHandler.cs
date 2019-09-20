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
            var content = new FormUrlEncodedContent(new[]
                    {
             new KeyValuePair<string, string>("taction", "addTaskSubtask"),
             new KeyValuePair<string, string>("title",parentZtask.TaskDetails.TaskTitle)
            });
            CancellationTokenSource cts = new CancellationTokenSource(30000);
            CancellationToken cancellationToken = cts.Token;
            HttpResponseMessage response = await NetworkHelper.Client.PostAsync("/zm/taskActionAPI.do", content, cancellationToken);
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

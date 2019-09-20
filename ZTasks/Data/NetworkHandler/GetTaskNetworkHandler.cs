using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZTasks.Data.DMNetworkHandlerContract;
using ZTasks.Data.NetworkCallback;
using ZTasks.Models;
namespace ZTasks.Data.NetworkHandler
{
    public class GetTaskNetworkHandler : IGetTaskNetworkHandlerContract
    {
        public GetTaskNetworkHandler()
        {

        }
        public async Task GetTasksAsync(IGetTasksNetworkCallback getTasksNetworkCallback)
        {
            await NetworkHelper.InitializeClientAsync();
            List<TaskUtilityModel> tasks = new List<TaskUtilityModel>();
            var content = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string, string>("taction", "getMyTasks"),
             new KeyValuePair<string, string>("limit", "499")
            });
            CancellationTokenSource cts = new CancellationTokenSource(30000);
            CancellationToken cancellationToken = cts.Token;
            HttpResponseMessage response = await NetworkHelper.Client.PostAsync("/zm/taskViewAPI.do", content, cancellationToken);
            var result = await response.Content.ReadAsStringAsync();
            //result = result.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
            //result = result.Substring(result.IndexOf('{'));
            Debug.WriteLine(result);
            //JObject jObject = JObject.Parse(result);
            JArray jarray = JArray.Parse(result);
            //Debug.WriteLine(jarray[1]["list"]);
            var attributes = jarray[1]["list"];
            foreach (JToken attribute in attributes)
            {
                JProperty jProperty = attribute.ToObject<JProperty>();
                string propertyName = jProperty.Name;
                var value = jProperty.Value;
                TaskUtilityModel model = new TaskUtilityModel();
                model.TaskId = propertyName;
                foreach (JToken token in value)
                {
                    JProperty jProp = token.ToObject<JProperty>();

                    if (jProp.Name == "TITLE")
                    {
                        model.TaskTitle = (string)jProp.Value;
                    }
                    else if (jProp.Name == "CREATEDTIME")
                    {
                        var date = (long)jProp.Value;
                        model.CreatedTime = DateTimeOffset.FromUnixTimeMilliseconds(date).Date;

                    }
                    else if (jProp.Name == "DUEDATEINMILLISECONDS")
                    {


                        var date = (long)jProp.Value;
                        if (date != -1)
                        {
                            model.DueDate = DateTimeOffset.FromUnixTimeMilliseconds(date).Date;
                        }

                    }
                    else if (jProp.Name == "UPDATEDTIME")
                    {
                        var date = (long)jProp.Value;
                        model.ModifiedDate = DateTimeOffset.FromUnixTimeMilliseconds(date).Date;
                    }
                    else if (jProp.Name == "PRIORITY")
                    {
                        model.Priority = (int)jProp.Value;
                    }
                    else if (jProp.Name == "STATUS")
                    {
                        model.TaskStatus = (int)jProp.Value;
                    }
                    else if (jProp.Name == "RD")
                    {
                        model.RemindOn = ((DateTimeOffset)jProp.Value).Date;
                    }
                    else if (jProp.Name == "SUMMARY")
                    {
                        model.Description = (string)jProp.Value;
                    }
                    else if (jProp.Name == "PARENTTASKID")
                    {
                        if (!((string)jProp.Value).Equals("-1"))
                        {
                            model.ParentTaskId = (string)jProp.Value;
                        }
                    }

                    else if (jProp.Name == "OWNERID")
                    {
                        model.AssignedById = (string)jProp.Value;
                    }
                    else if (jProp.Name == "ATTENDEEIDS")
                    {
                        model.AssigneeId = (string)jProp.Value;
                    }
                    //else if (jProp.Name == "TITLE")
                    //{
                    //    model.AssignedByName = (string)jProp.Value;
                    //}
                    //else if (jProp.Name == "TITLE")
                    //{
                    //    model.AssigneeName = (string)jProp.Value;
                    //}
                }

                Debug.WriteLine(model.DueDate);




                tasks.Add(model);

            }
            //foreach (JObject o in jarray.Children<JObject>())
            //{

            //    foreach (JProperty p in o.Properties())
            //    {

            //        string name = p.Name;
            //        //string value = (string)p.Value;
            //        Debug.WriteLine(name);
            //    }
            //}
            //JArray ja = (JArray)jObject["list"];
            // Debug.WriteLine(jObject["list"]);
            //foreach (JObject o in ja)
            //{
            //    Debug.WriteLine(o[""]);
            //}
            //Debug.WriteLine((string)jObject["list"]);
            await getTasksNetworkCallback.OnNetworkSyncSuccessful(tasks);

        }


    }

}

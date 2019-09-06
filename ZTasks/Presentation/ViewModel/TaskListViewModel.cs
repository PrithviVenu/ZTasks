using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ZTasks.Models;
using ZTasks.Domain.Usecase;
using ZTasks.Presentation.PresenterCallBackHandler;
using Windows.ApplicationModel.Core;
using System.Runtime.CompilerServices;

namespace ZTasks.Presentation.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged, IGetTaskPresenterCallBack
    {

        private List<ZTask> ZTaskCollection { get; set; }

        UseCaseBase usecase;
        private ObservableCollection<ZTask> _Ztasks;
        public ObservableCollection<ZTask> Ztasks { get { return _Ztasks; } set { _Ztasks = value; NotifyPropertyChanged(); } }
        public List<ZTask> Today { get; set; }
        public List<ZTask> Upcoming { get; set; }
        public List<ZTask> Delayed { get; set; }
        public List<ZTask> AssignedToOthers { get; set; }

        public TaskListViewModel()
        {
            ZTaskCollection = new List<ZTask>();
            Ztasks = new ObservableCollection<ZTask>();
            Today = new List<ZTask>();
            Upcoming = new List<ZTask>();
            Delayed = new List<ZTask>();
            AssignedToOthers = new List<ZTask>();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void MyTasks()
        {
            usecase = new GetTaskUseCase(this);

            usecase.Execute();

        }

        public async void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            //var v =System.Windows.Application.Current.Dispatcher;
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                //Debug.WriteLine(ZtaskList.Count, "msdmsdm");
                Ztasks.Clear();
                AddElementsToCollection(ZtaskList);
            });

            //Ztasks = new ObservableCollection<ZTask>(ZtaskList);

        }

        public void AddToLists(ZTask task)
        {
            if (task.Assignment.AssigneeId != "user101010")
            {
                AssignedToOthers.Add(task);
            }
            DateTimeOffset? offset = task.TaskDetails.DueDate;
            DateTime? dateTime = offset.HasValue ? offset.Value.DateTime : (DateTime?)null;

            if (dateTime != null)
            {
                if (dateTime?.Date == DateTime.Today)
                {
                    Today.Add(task);
                }

            }

        }
        public void AddElementsToCollection(List<ZTask> ZtaskList)
        {
            Debug.WriteLine(DateTime.Today, "Today");
            Debug.WriteLine(DateTime.Now, "TodayNow");
            Debug.WriteLine(DateTime.UtcNow, "TodayNowutc");

            foreach (ZTask task in ZtaskList)
            {
                DateTimeOffset? offset = task.TaskDetails.DueDate;
                DateTime? dateTime = offset.HasValue ? offset.Value.DateTime : (DateTime?)null;
                Debug.WriteLine(dateTime?.Date, task.TaskDetails.TaskTitle);
                ZTaskCollection.Add(task);

                //AddToLists(task);
                if (task.TaskDetails.ParentTaskId == null)
                {
                    Ztasks.Add(task);
                }
            }
        }
    }
}

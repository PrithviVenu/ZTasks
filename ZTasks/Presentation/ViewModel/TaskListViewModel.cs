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
using ZTasks.Utility;

namespace ZTasks.Presentation.ViewModel
{
    public class TaskListViewModel : INotifyPropertyChanged, IGetTaskPresenterCallBack
    {

        private List<ZTask> ZTaskCollection { get; set; }

        UseCaseBase usecase;
        private ObservableCollection<ZTask> _Ztasks;
        public ObservableCollection<ZTask> Ztasks { get { return _Ztasks; } set { _Ztasks = value; NotifyPropertyChanged(); } }
        public List<ZTask> Home { get; set; }
        public List<ZTask> Today { get; set; }
        public List<ZTask> Upcoming { get; set; }
        public List<ZTask> Delayed { get; set; }
        public List<ZTask> AssignedToOthers { get; set; }
        public TaskView taskView;
        public TaskListViewModel()
        {
            ZTaskCollection = new List<ZTask>();
            Ztasks = new ObservableCollection<ZTask>();
            Home = new List<ZTask>();
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
            taskView = TaskView.Home;

            usecase = new GetTaskUseCase(this);

            usecase.Execute();

        }
        public void MyTasksRefresh()
        {
            usecase = new GetTaskUseCase(this);

            usecase.Execute();

        }
        public void HomeTasks()
        {
            Ztasks.Clear();
            ConvertListData(Home);
        }
        public void TasksForToday()
        {
            taskView = TaskView.Today;
            Ztasks.Clear();
            ConvertListData(Today);
            Debug.WriteLine(Ztasks.Count);

        }
        public void TasksAssignedToOthers()
        {
            taskView = TaskView.AssignedToOthers;
            Ztasks.Clear();
            ConvertListData(AssignedToOthers);
            Debug.WriteLine(Ztasks.Count);

        }
        public void UpcomingTasks()
        {
            taskView = TaskView.Upcoming;
            Ztasks.Clear();
            ConvertListData(Upcoming);
            Debug.WriteLine(Ztasks.Count);

        }
        public void DelayedTasks()
        {
            taskView = TaskView.Delayed;
            Ztasks.Clear();
            ConvertListData(Delayed);
            Debug.WriteLine(Ztasks.Count);

        }

        public async void OnTasksFetchedSuccessfully(List<ZTask> ZtaskList)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Ztasks.Clear();
                Today.Clear();
                Upcoming.Clear();
                Delayed.Clear();
                AssignedToOthers.Clear();
                Home.Clear();
                AddElementsToCollection(ZtaskList);
            });


        }
        public void AddElementsToCollection(List<ZTask> ZtaskList)
        {
            foreach (ZTask task in ZtaskList)
            {
                AddToLists(task);
                ZTaskCollection.Add(task);
                Home.Add(task);
            }
            Display();
        }

        public void Display()
        {
            switch (taskView)
            {
                case TaskView.Home:
                    HomeTasks();
                    break;
                case TaskView.Today:
                    TasksForToday();
                    break;
                case TaskView.Upcoming:
                    UpcomingTasks();
                    break;
                case TaskView.Delayed:
                    DelayedTasks();
                    break;
                case TaskView.AssignedToOthers:
                    TasksAssignedToOthers();
                    break;
            }

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
                if (dateTime?.Date < DateTime.Today)
                {
                    Delayed.Add(task);
                }
                if (dateTime?.Date > DateTime.Today)
                {
                    Upcoming.Add(task);
                }
            }

        }
        public void ConvertListData(List<ZTask> ZtaskList)
        {
            foreach (ZTask task in ZtaskList)
            {
                Ztasks.Add(task);
            }
        }

    }
}

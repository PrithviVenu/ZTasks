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
using System.Threading.Tasks;
using System.Linq;

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

        public void Filter(FilterOperation filter)
        {
            List<ZTask> ZTaskList = new List<ZTask>();
            switch (taskView)
            {
                case TaskView.Home:
                    ZTaskList = Home;
                    break;
                case TaskView.Today:
                    ZTaskList = Today;
                    break;
                case TaskView.Upcoming:
                    ZTaskList = Upcoming;
                    break;
                case TaskView.Delayed:
                    ZTaskList = Delayed;
                    break;
                case TaskView.AssignedToOthers:
                    ZTaskList = AssignedToOthers;
                    break;
            }
            List<ZTask> FilteredZTaskList = new List<ZTask>();

            Task.Run(() =>
            {
                switch (filter)
                {
                    case FilterOperation.open:
                        foreach (ZTask task in ZTaskList)
                        {
                            if (task.TaskDetails.TaskStatus == 0)
                            {
                                FilteredZTaskList.Add(task);
                            }
                        }
                        break;
                    case FilterOperation.closed:
                        foreach (ZTask task in ZTaskList)
                        {
                            if (task.TaskDetails.TaskStatus == 1)
                            {
                                FilteredZTaskList.Add(task);
                            }
                        }
                        break;
                    case FilterOperation.Low:
                        foreach (ZTask task in ZTaskList)
                        {
                            if (task.TaskDetails.Priority == 0)
                            {
                                FilteredZTaskList.Add(task);
                            }
                        }
                        break;
                    case FilterOperation.Medium:
                        foreach (ZTask task in ZTaskList)
                        {
                            if (task.TaskDetails.Priority == 1)
                            {
                                FilteredZTaskList.Add(task);
                            }
                        }
                        break;
                    case FilterOperation.High:
                        foreach (ZTask task in ZTaskList)
                        {
                            if (task.TaskDetails.Priority == 2)
                            {
                                FilteredZTaskList.Add(task);
                            }
                        }
                        break;
                }
            });
            OnOperationCompletion(FilteredZTaskList);
        }

        public void Sort(SortOperation sort)
        {
            List<ZTask> ZTaskList = Ztasks.ToList<ZTask>();
            Task.Run(() =>
            {
                switch (sort)
                {
                    case SortOperation.DueDateAscending:
                        for (int i = 0; i < ZTaskList.Count; i++)
                        {
                            for (int j = i + 1; j < ZTaskList.Count; j++)
                            {
                                if (ZTaskList[i].TaskDetails.DueDate > ZTaskList[j].TaskDetails.DueDate || ZTaskList[i].TaskDetails.DueDate == null)
                                {
                                    var tempTask = ZTaskList[i];
                                    ZTaskList[i] = ZTaskList[j];
                                    ZTaskList[j] = tempTask;

                                }
                            }

                        }
                        break;
                    case SortOperation.DueDateDescending:
                        for (int i = 0; i < ZTaskList.Count; i++)
                        {
                            for (int j = i + 1; j < ZTaskList.Count; j++)
                            {
                                if (ZTaskList[i].TaskDetails.DueDate < ZTaskList[j].TaskDetails.DueDate || ZTaskList[i].TaskDetails.DueDate == null)
                                {
                                    var tempTask = ZTaskList[i];
                                    ZTaskList[i] = ZTaskList[j];
                                    ZTaskList[j] = tempTask;

                                }
                            }

                        }
                        break;
                    case SortOperation.ModifiedDateAscending:
                        for (int i = 0; i < ZTaskList.Count; i++)
                        {
                            for (int j = i + 1; j < ZTaskList.Count; j++)
                            {
                                if (ZTaskList[i].TaskDetails.ModifiedDate > ZTaskList[j].TaskDetails.ModifiedDate || ZTaskList[i].TaskDetails.ModifiedDate == null)
                                {
                                    var tempTask = ZTaskList[i];
                                    ZTaskList[i] = ZTaskList[j];
                                    ZTaskList[j] = tempTask;

                                }
                            }

                        }
                        break;
                    case SortOperation.ModifiedDateDescending:
                        for (int i = 0; i < ZTaskList.Count; i++)
                        {
                            for (int j = i + 1; j < ZTaskList.Count; j++)
                            {
                                if (ZTaskList[i].TaskDetails.ModifiedDate < ZTaskList[j].TaskDetails.ModifiedDate || ZTaskList[i].TaskDetails.ModifiedDate == null)
                                {
                                    var tempTask = ZTaskList[i];
                                    ZTaskList[i] = ZTaskList[j];
                                    ZTaskList[j] = tempTask;

                                }
                            }

                        }
                        break;
                }
            });

            OnOperationCompletion(ZTaskList);
        }

        public async void OnOperationCompletion(List<ZTask> ZtaskList)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Ztasks.Clear();
                foreach (ZTask task in ZtaskList)
                {
                    Ztasks.Add(task);
                }
            });


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

        }
        public void TasksAssignedToOthers()
        {
            taskView = TaskView.AssignedToOthers;
            Ztasks.Clear();
            ConvertListData(AssignedToOthers);

        }
        public void UpcomingTasks()
        {
            taskView = TaskView.Upcoming;
            Ztasks.Clear();
            ConvertListData(Upcoming);

        }
        public void DelayedTasks()
        {
            taskView = TaskView.Delayed;
            Ztasks.Clear();
            ConvertListData(Delayed);

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
                if (dateTime?.Date == DateTime.Today && task.TaskDetails.TaskStatus == 0)
                {
                    Today.Add(task);
                }
                if (dateTime?.Date < DateTime.Today && task.TaskDetails.TaskStatus == 0)
                {
                    Delayed.Add(task);
                }
                if (dateTime?.Date > DateTime.Today && task.TaskDetails.TaskStatus == 0)
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

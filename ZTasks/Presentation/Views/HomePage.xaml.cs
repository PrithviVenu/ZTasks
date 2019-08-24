using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using ZTasks.Domain.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZTasks.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private ObservableCollection<ZTask> tasks;

        public HomePage()
        {
            this.InitializeComponent();
            tasks = new ObservableCollection<ZTask>();
            tasks.CollectionChanged += Task_CollectionChanged;
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "", ProjectId = "", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "", ProjectId = "", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
            //tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", CreatedTime = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, GroupId = "98739udh", ProjectId = "pro982j", ParentTaskId = "1001" });
        }
        void Task_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (tasks.Count == 0)
            {
                EmptyAddTaskDisplayPanel.Visibility = Visibility.Visible;
                TasksListView.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyAddTaskDisplayPanel.Visibility = Visibility.Collapsed;
                TasksListView.Visibility = Visibility.Visible;

            }

        }

        public void ItemClick(object sender, RoutedEventArgs e)
        {
            ShowSlideInPane();

        }

        public void AddNewTask(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(AddTaskPage), this, new SuppressNavigationTransitionInfo());
            ShowSlideInPane();
            //CollapseSlideInPane();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                MainPage mainPage = (MainPage)e.Parameter;
                mainPage.AddTaskClicked += this.AddNewTask;
            }

        }
        public void CollapseSlideInPane()
        {
            TasksListView.Margin = new Thickness(10, 10, 10, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 2);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 2);
            //TopPanel.SetValue(Grid.ColumnSpanProperty, 2);
            SlideInPane.Visibility = Visibility.Collapsed;

        }
        private void ShowSlideInPane()
        {

            TasksListView.Margin = new Thickness(0, 0, 0, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 1);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 1);
            //TopPanel.SetValue(Grid.ColumnSpanProperty, 1);
            SlideInPane.Visibility = Visibility.Visible;

        }


    }
}

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
            tasks.CollectionChanged += task_CollectionChanged;
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = DateTime.Now, DueDate = DateTime.Now, Priority = "High", RemindOn = DateTime.Now, ParentTaskId = "1001" });

        }
        void task_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (tasks.Count == 0)
            {
                EmptyAddTaskDisplayPanel.Visibility = Visibility.Visible;
            }
            else
            {
                EmptyAddTaskDisplayPanel.Visibility = Visibility.Collapsed;

            }

        }

        public void ItemClick(object sender, RoutedEventArgs e)
        {
            TasksListView.Margin = new Thickness(0, 0, 0, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 1);
            SlideInPane.Visibility = Visibility.Visible;
        }

        public void AddNewTask(object sender, RoutedEventArgs e)
        {
            TasksListView.Margin = new Thickness(0, 0, 0, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 1);
            SlideInPane.Visibility = Visibility.Visible;
        }


    }
}

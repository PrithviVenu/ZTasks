using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZTasks.Models;
using ZTasks.Presentation.ViewModel;
using ZTasks.Utility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZTasks.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOrModifyTaskPage : Page, INotifyPropertyChanged
    {

        public ObservableCollection<ZTask> subtasks;
        private ZTask zTask;
        public ZTask TaskObj { get { return zTask; } set { zTask = value; NotifyPropertyChanged(); } }
        private string TaskId = "";
        public delegate void Collapse();
        public event Collapse CollapseClicked;
        public delegate void Refresh(ZTask task);
        public event Refresh RefreshData;
        public event PropertyChangedEventHandler PropertyChanged;
        public CreateOrModifyTaskViewModel createTaskViewModel;
        public CreateOrModifyUserControl userControlObj;
        public delegate void UserControlAddEvent();
        public event UserControlAddEvent UserControlAddEventTriggered;
        public ZTask newRowSubTask;
        public TaskOperation taskOperation;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CreateOrModifyTaskPage()
        {
            this.InitializeComponent();
            createTaskViewModel = new CreateOrModifyTaskViewModel();
            this.DataContext = createTaskViewModel;
            PageSetup();
        }


        public void PageSetup()
        {

            TaskId = "";
            subtasks = createTaskViewModel.Ztasks;
            subtasks.Clear();
            ZTask zTask = new ZTask();
            TaskDetail taskDetail = zTask.TaskDetails;
            taskDetail.TaskId = GetTaskId();
            Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", taskDetail.TaskId);
            TaskObj = zTask; TaskObj.TaskDetails.CreatedTime = DateTime.Now.Date;
            ZTask zSubTask = new ZTask();
            TaskDetail subTaskDetail = zSubTask.TaskDetails;
            subTaskDetail.CreatedTime = DateTime.Now.Date;
            subTaskDetail.TaskId = Guid.NewGuid().ToString();
            subTaskDetail.ParentTaskId = GetTaskId();
            Assignment(zSubTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
            subtasks.Add(zSubTask);
            Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
            PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
            TaskObj.TaskDetails.Priority = 0;
        }
        private void CreateOrModifyUserControlLoaded(object sender, RoutedEventArgs e)
        {
            userControlObj = (CreateOrModifyUserControl)sender;
            userControlObj.EnterKeyDown -= Box_KeyDown;
            userControlObj.EnterKeyDown += Box_KeyDown;
            userControlObj.SetEventPageReference(this);
            userControlObj.DeleteButtonClicked -= DeleteSubTask;
            userControlObj.DeleteButtonClicked += DeleteSubTask;
        }

        public void Assignment(TaskAssignment taskAssignment, string AssignedById, string AssigneeId, string AssigneeName, string AssignedByName, string TaskId)
        {
            taskAssignment.AssignedById = AssignedById;
            taskAssignment.AssigneeId = AssigneeId;
            taskAssignment.AssigneeName = AssigneeName;
            taskAssignment.AssignedByName = AssignedByName;
            taskAssignment.TaskId = TaskId;
        }
        public void AddAssigneeToTask(object sender, RoutedEventArgs e)
        {
            //AddAssigneePopup.IsOpen = !AddAssigneePopup.IsOpen;

        }

        public void PriorityClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem)sender;
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);

            if ((string)item.Tag == "2")
            {
                High.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 217, 72, 59));
                TaskObj.TaskDetails.Priority = 2;
            }
            else if ((string)item.Tag == "1")
            {
                Medium.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 188, 210));
                TaskObj.TaskDetails.Priority = 1;

            }
            else if ((string)item.Tag == "0")

            {
                Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
                TaskObj.TaskDetails.Priority = 0;

            }

        }
        public void Printpriority()
        {
            foreach (ZTask task in subtasks)
            {
                Debug.WriteLine(task.TaskDetails.Priority);

            }
        }

        public string GetTaskId()
        {
            if (TaskId == "")
            {
                TaskId = Guid.NewGuid().ToString();
            }

            return TaskId;

        }

        private void CheckBoxClicked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                Reminder.IsEnabled = true;
            }
            else
            {
                Reminder.IsEnabled = false;
                TaskObj.TaskDetails.RemindOn = null;
            }


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                HomePage Page = (HomePage)e.Parameter;
                SetEvents(Page);
            }

        }


        public void SetEvents(HomePage Page)
        {
            this.CollapseClicked -= Page.CollapseSlideInPane;
            this.CollapseClicked += Page.CollapseSlideInPane;
            this.RefreshData -= Page.RefreshTask;
            this.RefreshData += Page.RefreshTask;
            Page.TaskClicked -= TaskItemClick;
            Page.TaskClicked += TaskItemClick;
            Page.AddEvent -= AddEvent;
            Page.AddEvent += AddEvent;
            createTaskViewModel.RefreshData -= RefreshList;
            createTaskViewModel.RefreshData += RefreshList;
        }



        public void AddEvent()
        {
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);
            checkBox.IsChecked = false;
            Reminder.IsEnabled = false;
            TaskObj.TaskDetails.RemindOn = null;
            taskOperation = TaskOperation.Add;
            Debug.WriteLine("Add Event");
            PageSetup();
            UserControlAddEventTriggered?.Invoke();

        }


        public void RefreshList(ZTask task)
        {
            RefreshData?.Invoke(task);
            taskOperation = TaskOperation.Modify;

        }
        private void LoseFocus(object sender)
        {
            var control = sender as Control;
            var isTabStop = control.IsTabStop;
            control.IsTabStop = false;
            control.IsEnabled = false;
            control.IsEnabled = true;
            control.IsTabStop = isTabStop;
        }

        public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement
        {

            if (parent == null) return null;
            if (parent.GetType() == targetType && ((T)parent).Name == ControlName) return (T)parent;

            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
                T result = FindControl<T>(child, targetType, ControlName);
                if (result != null) return result;
            }
            return null;
        }

        private void Task_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            if (e.Key == Windows.System.VirtualKey.Enter && subtasks.Count == 0 && !string.IsNullOrWhiteSpace(b.Text))
            {
                ZTask zTask = new ZTask();
                TaskDetail subTaskDetail = zTask.TaskDetails;
                subTaskDetail.TaskId = Guid.NewGuid().ToString();
                subTaskDetail.ParentTaskId = GetTaskId();
                subTaskDetail.CreatedTime = DateTime.Now.Date;
                newRowSubTask = zTask;
                Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
                subtasks.Add(zTask);
                // e.Handled = true; LoseFocus(sender);
            }
        }
        private void Box_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            ZTask task1 = (ZTask)b.DataContext;
            task1.TaskDetails.TaskTitle = b.Text;
            Debug.WriteLine(task1.TaskDetails.TaskTitle);
            if (subtasks.Last() == task1 && !string.IsNullOrWhiteSpace(b.Text))
            {
                ZTask zTask = new ZTask();
                TaskDetail subTaskDetail = zTask.TaskDetails;
                subTaskDetail.TaskId = Guid.NewGuid().ToString();
                subTaskDetail.ParentTaskId = GetTaskId();
                subTaskDetail.CreatedTime = DateTime.Now.Date;
                //newRowSubTask = zTask;
                Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
                subtasks.Add(zTask);
                //e.Handled = true; LoseFocus(sender);

            }
        }
        private void ShowCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            CalendarPopup.IsOpen = !CalendarPopup.IsOpen;
        }
        private async void SaveTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle.Text))
            {
                createTaskViewModel.AddOrModifyTask(TaskObj, taskOperation);
            }
            else
            {
                MessageDialog showDialog = new MessageDialog("Please Enter Title");
                showDialog.Commands.Add(new UICommand("Ok")
                {
                });
                await showDialog.ShowAsync();


            }
        }



        public void ModifyPriority(ZTask zTask)
        {
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);
            if (zTask.TaskDetails.Priority == 0)
            {
                Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
            }
            else if (zTask.TaskDetails.Priority == 1)
            {
                Medium.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 188, 210));
            }
            else if (zTask.TaskDetails.Priority == 2)
            {
                High.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 217, 72, 59));
            }

        }

        public void TaskItemClick(ZTask item)
        {
            taskOperation = TaskOperation.Modify;
            TaskObj = item;
            TaskId = TaskObj.TaskDetails.TaskId;
            ModifyPriority(item);
            if (TaskObj.TaskDetails.RemindOn == null)
            {
                Reminder.IsEnabled = false;
                checkBox.IsChecked = false;
            }
            else
            {
                Reminder.IsEnabled = true;
                checkBox.IsChecked = true;
            }
            subtasks.Clear();
            foreach (ZTask subTask in item.SubTasks)
            {
                subtasks.Add(subTask);
                Debug.WriteLine(subTask.TaskDetails.TaskTitle);
            }
            if (subtasks.Count == 0)
            {
                ZTask zTask = new ZTask();
                TaskDetail subTaskDetail = zTask.TaskDetails;
                subTaskDetail.TaskId = Guid.NewGuid().ToString();
                subTaskDetail.ParentTaskId = GetTaskId();
                newRowSubTask = zTask;
                Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
                subtasks.Add(zTask);

            }
            Debug.WriteLine(item.TaskDetails.TaskTitle);
        }
        public async void DeleteSubTask(object sender, RoutedEventArgs e)
        {
            Button item = (Button)sender;
            //Debug.WriteLine(item.Text, item.Name);
            ZTask task = (ZTask)item.DataContext;
            // Debug.WriteLine("delete");
            MessageDialog showDialog = new MessageDialog("Do you wish to delete this task ?");
            showDialog.Commands.Add(new UICommand("Yes")
            {
                Id = 0
            });
            showDialog.Commands.Add(new UICommand("No")
            {
                Id = 1
            });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();
            if ((int)result.Id == 0)
            {
                subtasks.Remove(task);
            }
            else
            {
            }
        }

        public void CollapseSlideInPane(object sender, RoutedEventArgs e)
        {
            CollapseClicked?.Invoke();
        }


    }
}

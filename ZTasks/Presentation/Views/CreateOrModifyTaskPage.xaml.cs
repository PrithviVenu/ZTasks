using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation.Collections;
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
        public ZTask task { get { return zTask; } set { zTask = value; NotifyPropertyChanged(); } }

        private string TaskId = "";
        public delegate void Collapse();
        public event Collapse CollapseClicked;
        public delegate void Refresh();
        public event Refresh RefreshData;
        public delegate void ListViewClick(object sender, RoutedEventArgs e);
        public event ListViewClick ListViewClicked;
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
            task = zTask;
            ZTask zSubTask = new ZTask();
            TaskDetail subTaskDetail = zSubTask.TaskDetails;
            subTaskDetail.TaskId = Guid.NewGuid().ToString(); subTaskDetail.ParentTaskId = GetTaskId();
            Assignment(zSubTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
            subtasks.Add(zSubTask);
            Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
            PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
            task.TaskDetails.Priority = 0;
        }
        private void CreateOrModifyUserControlLoaded(object sender, RoutedEventArgs e)
        {
            userControlObj = (CreateOrModifyUserControl)sender;
            userControlObj.EnterKeyDown -= Box_KeyDown;
            userControlObj.EnterKeyDown += Box_KeyDown;
            userControlObj.SetEventPageReference(this);
            userControlObj.DeleteButtonClicked -= DeleteSubTask;
            userControlObj.DeleteButtonClicked += DeleteSubTask;
            //userControlObj.TextContextChanged += TextBox_DataContextChanged;
            //userControlObj.DataContextChanged += UserControlObj_DataContextChanged;


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
            //Debug.WriteLine(item.Text, item.Name);
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);

            if ((string)item.Tag == "2")
            {
                High.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 217, 72, 59));
                task.TaskDetails.Priority = 2;
            }
            else if ((string)item.Tag == "1")
            {
                Medium.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 188, 210));
                task.TaskDetails.Priority = 1;

            }
            else if ((string)item.Tag == "0")

            {
                Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
                task.TaskDetails.Priority = 0;

            }
            //  printpriority();

        }
        public void Printpriority()
        {
            foreach (ZTask task in subtasks)
            {
                Debug.WriteLine(task.TaskDetails.Priority);

            }
        }

        //private bool _focusItem = true;
        //private void UserControlObj_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        //{
        //    FocusLastAddUserControl((AddUserControl)sender);
        //}

        //private void FocusLastAddUserControl(AddUserControl control)
        //{

        //    //last item, focus it
        //    Debug.WriteLine(SubTasksListView.Items.Count, "dddddddd");
        //    control.FocusTextBox();
        //    //_focusItem = false;
        //}
        public string GetTaskId()
        {
            if (TaskId == "")
            {
                TaskId = Guid.NewGuid().ToString();
            }

            return TaskId;

        }

        //private void TextBox_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        //{
        //    var textBox = (TextBox)sender;
        //    if (args.NewValue == SubTasksListView.Items[SubTasksListView.Items.Count - 1] && _focusItem)
        //    {
        //        //last item, focus it
        //        textBox.Focus(FocusState.Programmatic);
        //        _focusItem = false;
        //    }

        //}

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
                task.TaskDetails.RemindOn = null;
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
            this.RefreshData -= Page.HomePageRefresh;
            this.RefreshData += Page.HomePageRefresh;
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
            taskOperation = TaskOperation.Add;
            Debug.WriteLine("Add Event");
            PageSetup();
            UserControlAddEventTriggered?.Invoke();

        }


        public void RefreshList()
        {
            RefreshData?.Invoke();
            taskOperation = TaskOperation.Modify;
            // PriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));

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
        private void ListView_GotFocus(object sender, RoutedEventArgs e)
        {
            // If user clicks on a control in the row, select entire row
            SubTasksListView.SelectedItem = (sender as ListView).DataContext;
        }
        private void ListViewItems_VectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
        {

            // If new row added, at this point we can safely select and scroll to new item
            if (newRowSubTask != null)
            {
                Debug.WriteLine(SubTasksListView.Items.Count, "count");

                SubTasksListView.SelectedIndex = SubTasksListView.Items.Count - 1; // select row
                SubTasksListView.ScrollIntoView(SubTasksListView.Items[SubTasksListView.Items.Count - 1]);   // scroll to bottom; this will make sure new row is visible and that DataContextChanged is called
                Debug.WriteLine(SubTasksListView.Items.Count, "count");
                userControlObj.FocusTextBox();
            }
        }

        private void ListView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Debug.WriteLine("ListView_DataContextChanged");

            // If new row added, at this point the UI is created and we can set focus to text box 
            if (newRowSubTask != null)
            {
                ListView listView = (ListView)sender;
                ZTask zTask = (ZTask)listView.DataContext;  // might be null

                if (zTask == newRowSubTask)
                {
                    TextBox textBox = FindControl<TextBox>(listView, typeof(TextBox), "SubTaskTitle");
                    if (textBox != null)
                    {
                        textBox.Focus(FocusState.Programmatic);
                    }
                    newRowSubTask = null;
                }
            }
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

                subTaskDetail.TaskId = Guid.NewGuid().ToString(); subTaskDetail.ParentTaskId = GetTaskId();
                newRowSubTask = zTask;
                Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
                subtasks.Add(zTask);
                //Debug.WriteLine(SubTasksListView.Items.Count, "count");

                e.Handled = true; LoseFocus(sender);

                //SubTasksListView?.ScrollIntoView(SubTasksListView.Items[subtasks.Count - 1], ScrollIntoViewAlignment.Leading);
                //FocusLastAddUserControl(userControlObj);

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
                subTaskDetail.TaskId = Guid.NewGuid().ToString(); subTaskDetail.ParentTaskId = GetTaskId();
                newRowSubTask = zTask;
                Assignment(zTask.Assignment, "user101010", "user101010", "Prithvi Venu", "Prithvi Venu", subTaskDetail.TaskId);
                subtasks.Add(zTask);
                //Debug.WriteLine(SubTasksListView.Items.Count, "count");

                e.Handled = true; LoseFocus(sender);

                //SubTasksListView?.ScrollIntoView(SubTasksListView.Items[subtasks.Count - 1], ScrollIntoViewAlignment.Leading);
                //FocusLastAddUserControl(userControlObj);



            }


            //task1.AssignedBy = "101";

            //Debug.WriteLine(task1.AssignedBy, task1.AssignedBy);



        }
        private void ShowCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // calendarPopup.IsOpen = true;
            CalendarPopup.IsOpen = !CalendarPopup.IsOpen;
        }
        private async void SaveTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle.Text))
            {
                // Debug.WriteLine(task.DueDate, "hoiii");
                //tasks.Add(new ZTask { TaskId = GetTaskId(), TaskTitle = TaskTitle.Text });
                createTaskViewModel.AddOrModifyTask(task, taskOperation);
                //TaskId = "";
                //tasks.Clear();
            }
            else
            {
                MessageDialog showDialog = new MessageDialog("Please Enter Title");
                showDialog.Commands.Add(new UICommand("Ok")
                {
                    // Id = 0
                });
                //showDialog.DefaultCommandIndex = 0;
                await showDialog.ShowAsync();
                //if ((int)result.Id == 0)
                //{
                //    //do your task  
                //}

            }
        }


        public void ItemClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(SubTasksListView.SelectedIndex, "AddTaskPage");
            ListViewClicked?.Invoke(sender, e);
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
            task = item;
            TaskId = task.TaskDetails.TaskId;
            ModifyPriority(item);
            //task.TaskDetails = item.TaskDetails;
            //task.Assignment = item.Assignment;
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
                subTaskDetail.TaskId = Guid.NewGuid().ToString(); subTaskDetail.ParentTaskId = GetTaskId();
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

        private void SubTasksListView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {

        }

        private void ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void RelativePanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}

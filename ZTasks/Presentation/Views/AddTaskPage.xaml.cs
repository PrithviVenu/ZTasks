using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ZTasks.Presentation.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ZTasks.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTaskPage : Page
    {
        private ObservableCollection<ZTask> subtasks;
        private ZTask task;
        private string TaskId = "";
        public delegate void Collapse();
        public event Collapse CollapseClicked;
        public delegate void Refresh();
        public event Refresh RefreshData;
        public delegate void ListViewClick(object sender, RoutedEventArgs e);
        public event ListViewClick ListViewClicked;
        public CreateTaskViewModel createTaskViewModel;
        public AddUserControl userControlObj;
        public AddTaskPage()
        {
            this.InitializeComponent();
            //subtasks = new ObservableCollection<ZTask>();

            createTaskViewModel = new CreateTaskViewModel();
            this.DataContext = createTaskViewModel;
            subtasks = createTaskViewModel.Ztasks;
            task = new ZTask { TaskId = GetTaskId(), TaskTitle = TaskTitle.Text };
            subtasks.Add(new ZTask { TaskId = Guid.NewGuid().ToString(), ParentTaskId = GetTaskId() });
        }
        private void AddUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            userControlObj = (AddUserControl)sender;
            userControlObj.EnterKeyDown += Box_KeyDown;
            userControlObj.SetEventPageReference(this);
            //userControlObj.TextContextChanged += TextBox_DataContextChanged;
            //userControlObj.DataContextChanged += UserControlObj_DataContextChanged;


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
            }


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                HomePage Page = (HomePage)e.Parameter;
                this.CollapseClicked += Page.CollapseSlideInPane;
                this.RefreshData += Page.GetListData;
                createTaskViewModel.RefreshData += refresh;
            }

        }

        public void refresh()
        {
            RefreshData?.Invoke();
            Debug.WriteLine(999999);

        }
        private void Box_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBox b = (TextBox)sender;
            ZTask task1 = (ZTask)b.DataContext;
            task1.TaskTitle = b.Text;
            Debug.WriteLine(task1.TaskTitle);
            if (subtasks.Last() == task1)
            {
                if (!b.Text.Equals(""))
                {
                    subtasks.Add(new ZTask { TaskId = Guid.NewGuid().ToString(), ParentTaskId = GetTaskId() });
                    //SubTasksListView?.ScrollIntoView(SubTasksListView.Items[subtasks.Count - 1], ScrollIntoViewAlignment.Leading);
                    //FocusLastAddUserControl(userControlObj);

                }
            }
            else
            {

            }

            //task1.AssignedBy = "101";

            //Debug.WriteLine(task1.AssignedBy, task1.AssignedBy);



        }
        private void ShowCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // calendarPopup.IsOpen = true;
            CalendarPopup.IsOpen = !CalendarPopup.IsOpen;
        }
        private void SaveTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle.Text))
            {
                Debug.WriteLine(task.DueDate, "hoiii");
                //tasks.Add(new ZTask { TaskId = GetTaskId(), TaskTitle = TaskTitle.Text });
                createTaskViewModel.AddTask(task);
                //TaskId = "";
                //tasks.Clear();
            }
        }
        private void CancelTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle.Text))
            {

            }
        }

        public void ItemClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(SubTasksListView.SelectedIndex, "AddTaskPage");
            ListViewClicked?.Invoke(sender, e);
        }

        public void CollapseSlideInPane(object sender, RoutedEventArgs e)
        {
            CollapseClicked?.Invoke();
        }



    }
}

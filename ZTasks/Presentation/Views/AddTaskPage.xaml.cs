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
        public delegate void Collapse();
        public event Collapse CollapseClicked;
        public delegate void ListViewClick(object sender, RoutedEventArgs e);
        public event ListViewClick ListViewClicked;
        HomeViewModel homeViewModel;

        public AddTaskPage()
        {
            this.InitializeComponent();
            subtasks = new ObservableCollection<ZTask>();
            //homeViewModel = new HomeViewModel(ref subtasks);
            subtasks.Add(new ZTask { TaskId = Guid.NewGuid().ToString() });
        }
        private void AddUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var userControlObj = (AddUserControl)sender;
            userControlObj.EnterKeyDown += Box_KeyDown;
            userControlObj.SetEventPageReference(this);
            userControlObj.TextContextChanged += TextBox_DataContextChanged;

        }
        private bool _focusItem = true;


        private void TextBox_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var textBox = (TextBox)sender;
            if (args.NewValue == SubTasksListView.Items[SubTasksListView.Items.Count - 1] && _focusItem)
            {
                //last item, focus it
                textBox.Focus(FocusState.Programmatic);
                _focusItem = false;
            }

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
            }


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                HomePage Page = (HomePage)e.Parameter;
                this.CollapseClicked += Page.CollapseSlideInPane;
            }

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
                    subtasks.Add(new ZTask { TaskId = Guid.NewGuid().ToString() });
                    //SubTasksListView?.ScrollIntoView(SubTasksListView.Items[subtasks.Count - 1], ScrollIntoViewAlignment.Leading);


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

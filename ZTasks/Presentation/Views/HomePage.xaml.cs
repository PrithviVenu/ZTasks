using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
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
    public sealed partial class HomePage : Page
    {
        private ObservableCollection<ZTask> tasks;
        public TaskListViewModel taskListViewModel;
        public delegate void TaskEventHandler(ZTask item);
        public event TaskEventHandler TaskClicked;
        public delegate void AddEventHandler();
        public event AddEventHandler AddEvent;
        public TaskView taskView;

        public HomePage()
        {
            this.InitializeComponent();
            taskListViewModel = new TaskListViewModel();
            this.DataContext = taskListViewModel;
            tasks = taskListViewModel.Ztasks;
            HomePageSetup();
            tasks.CollectionChanged -= Task_CollectionChanged;
            tasks.CollectionChanged += Task_CollectionChanged;
        }

        public void HomePageSetup()
        {
            taskView = TaskView.Home;
            Title.Text = "Home";
            taskListViewModel.MyTasks();
        }
        public void HomePageRefresh()
        {
            taskListViewModel.MyTasksRefresh();
        }
        public void TodayPageSetup()
        {
            taskView = TaskView.Today;
            Title.Text = "Today";
            taskListViewModel.TasksForToday();
        }

        public void UpcomingPageSetup()
        {
            taskView = TaskView.Upcoming;
            Title.Text = "Upcoming";
            taskListViewModel.UpcomingTasks();

        }

        public void DelayedPageSetup()
        {
            taskView = TaskView.Delayed;
            Title.Text = "Delayed";
            taskListViewModel.DelayedTasks();

        }

        public void AssignedToOthersPageSetup()
        {
            taskView = TaskView.AssignedToOthers;
            Title.Text = "Assigned To Others";
            taskListViewModel.TasksAssignedToOthers();

        }

        public void Filter(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem)sender;
            if ((string)item.Tag == "Open")
            {
                taskListViewModel.Filter(FilterOperation.open);
            }
            else if ((string)item.Tag == "Closed")
            {
                taskListViewModel.Filter(FilterOperation.closed);
            }
            else if ((string)item.Tag == "High")
            {
                taskListViewModel.Filter(FilterOperation.High);

            }
            else if ((string)item.Tag == "Medium")
            {
                taskListViewModel.Filter(FilterOperation.Medium);
            }
            else if ((string)item.Tag == "Low")
            {
                taskListViewModel.Filter(FilterOperation.Low);
            }
        }

        public void Sort(object sender, RoutedEventArgs e)
        {

            MenuFlyoutItem item = (MenuFlyoutItem)sender;
            if ((string)item.Tag == "DueDateAsc")
            {
                taskListViewModel.Sort(SortOperation.DueDateAscending);
            }
            else if ((string)item.Tag == "DueDateDesc")
            {
                taskListViewModel.Sort(SortOperation.DueDateDescending);

            }
            else if ((string)item.Tag == "ModifiedDateAsc")
            {
                taskListViewModel.Sort(SortOperation.ModifiedDateAscending);

            }
            else if ((string)item.Tag == "ModifiedDateDesc")
            {
                taskListViewModel.Sort(SortOperation.ModifiedDateDescending);

            }

        }
        private void ListTasksUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var userControlObj = (HomeListControl)sender;


        }
        void Task_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (tasks.Count == 0)
            {
                if (taskView == TaskView.Home || taskView == TaskView.Today)
                {
                    EmptyAddTaskDisplayPanel.Visibility = Visibility.Visible;
                    EmptyTaskDisplayPanel.Visibility = Visibility.Collapsed;

                }
                else
                {
                    EmptyAddTaskDisplayPanel.Visibility = Visibility.Collapsed;
                    EmptyTaskDisplayPanel.Visibility = Visibility.Visible;
                }
                TasksListView.Visibility = Visibility.Collapsed;

            }
            else
            {
                EmptyAddTaskDisplayPanel.Visibility = Visibility.Collapsed;
                EmptyTaskDisplayPanel.Visibility = Visibility.Collapsed;
                TasksListView.Visibility = Visibility.Visible;
            }
        }


        public void ItemClick(object sender, ItemClickEventArgs e)
        {

            MyFrame.BackStack.Clear();
            MyFrame.Navigate(typeof(CreateOrModifyTaskPage), this, new SuppressNavigationTransitionInfo());
            ZTask item = (ZTask)e.ClickedItem;
            TaskClicked?.Invoke(item);
            ShowSlideInPane();
        }

        public void AddNewTask(object sender, RoutedEventArgs e)
        {
            MyFrame.BackStack.Clear();
            MyFrame.Navigate(typeof(CreateOrModifyTaskPage), this, new SuppressNavigationTransitionInfo());
            ShowSlideInPane();
            AddEvent?.Invoke();
            //CollapseSlideInPane();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                MainPage mainPage = (MainPage)e.Parameter;
                SetEvents(mainPage);
            }

        }

        public void SetEvents(MainPage mainPage)
        {
            mainPage.AddTaskClicked -= AddNewTask;
            mainPage.AddTaskClicked += AddNewTask;
            mainPage.RefreshEventClicked -= HomePageRefresh;
            mainPage.RefreshEventClicked += HomePageRefresh;
            mainPage.HomeEvent -= HomePageSetup;
            mainPage.HomeEvent += HomePageSetup;
            mainPage.TodayEvent -= TodayPageSetup;
            mainPage.TodayEvent += TodayPageSetup;
            mainPage.UpcomingEvent -= UpcomingPageSetup;
            mainPage.UpcomingEvent += UpcomingPageSetup;
            mainPage.DelayedEvent -= DelayedPageSetup;
            mainPage.DelayedEvent += DelayedPageSetup;
            mainPage.AssignedToOthersEvent -= AssignedToOthersPageSetup;
            mainPage.AssignedToOthersEvent += AssignedToOthersPageSetup;
        }


        public void CollapseSlideInPane()
        {
            TasksListView.SelectedIndex = -1;
            //TasksListView.Margin = new Thickness(10, 10, 10, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 2);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 2);
            TopPanel.SetValue(Grid.ColumnSpanProperty, 2);
            SlideInPane.Visibility = Visibility.Collapsed;

        }
        private void ShowSlideInPane()
        {

            //TasksListView.Margin = new Thickness(0, 0, 0, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 1);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 1);
            if (tasks.Count > 0)
            {

                TopPanel.SetValue(Grid.ColumnSpanProperty, 1);
            }
            SlideInPane.Visibility = Visibility.Visible;

        }

    }
}

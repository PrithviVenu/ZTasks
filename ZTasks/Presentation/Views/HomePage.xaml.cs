using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using ZTasks.Models;
using ZTasks.Presentation.ViewModel;

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
        public delegate void TaskEventHandler(object sender, ItemClickEventArgs args);
        public event TaskEventHandler TaskClicked;
        public delegate void AddEventHandler();
        public event AddEventHandler AddEvent;

        public HomePage()
        {
            this.InitializeComponent();
            taskListViewModel = new TaskListViewModel();
            this.DataContext = taskListViewModel;
            PageSetup();

        }

        public void PageSetup()
        {
            tasks = taskListViewModel.Ztasks;
            tasks.CollectionChanged -= Task_CollectionChanged;
            tasks.CollectionChanged += Task_CollectionChanged;
            GetListData();
        }
        private void ListTasksUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var userControlObj = (ListTasksControl)sender;


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

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine(MyFrame.BackStack.Count, "iiiiii");

            MyFrame.BackStack.Clear();
            Debug.WriteLine(MyFrame.BackStack.Count, "ooooo");

            MyFrame.Navigate(typeof(AddTaskPage), this, new SuppressNavigationTransitionInfo());

            Debug.WriteLine(MyFrame.BackStack.Count, "ggggg");

            Debug.WriteLine("homeclick");
            TaskClicked?.Invoke(sender, e);
            ShowSlideInPane();
        }

        public void AddNewTask(object sender, RoutedEventArgs e)
        {
            MyFrame.BackStack.Clear();
            MyFrame.Navigate(typeof(AddTaskPage), this, new SuppressNavigationTransitionInfo());
            ShowSlideInPane();
            AddEvent?.Invoke();
            //CollapseSlideInPane();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e != null)
            {
                MainPage mainPage = (MainPage)e.Parameter;
                mainPage.AddTaskClicked += AddNewTask;
                mainPage.HomeEvent += PageSetup;
            }

        }

        public void GetListData()
        {
            taskListViewModel.MyTasks();
        }
        public void CollapseSlideInPane()
        {
            //TasksListView.Margin = new Thickness(10, 10, 10, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 2);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 2);
            //TopPanel.SetValue(Grid.ColumnSpanProperty, 2);
            SlideInPane.Visibility = Visibility.Collapsed;

        }
        private void ShowSlideInPane()
        {

            //TasksListView.Margin = new Thickness(0, 0, 0, 0);
            TasksListView.SetValue(Grid.ColumnSpanProperty, 1);
            //EmptyAddTaskDisplayPanel.SetValue(Grid.ColumnSpanProperty, 1);
            //TopPanel.SetValue(Grid.ColumnSpanProperty, 1);
            SlideInPane.Visibility = Visibility.Visible;

        }

    }
}

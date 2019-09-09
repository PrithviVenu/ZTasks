using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using ZTasks.Presentation.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZTasks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.ss
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public delegate void AddTaskEventHandler(object sender, RoutedEventArgs args);
        public event AddTaskEventHandler AddTaskClicked;
        public delegate void RefreshEvent();
        public event RefreshEvent RefreshEventClicked;
        public delegate void HomeEventHandler();
        public event HomeEventHandler HomeEvent;
        public delegate void TodayEventHandler();
        public event TodayEventHandler TodayEvent;
        public delegate void UpcomingEventHandler();
        public event UpcomingEventHandler UpcomingEvent;
        public delegate void DelayedEventHandler();
        public event DelayedEventHandler DelayedEvent;
        public delegate void AssignedToOthersEventHandler();
        public event AssignedToOthersEventHandler AssignedToOthersEvent;
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            Window.Current.SetTitleBar(trickyTitleBar);
            UserName.Text = "Prithvi Venu";
            MyFrame.Navigate(typeof(HomePage), this, new SuppressNavigationTransitionInfo());
            Home.IsSelected = true;
            Home.Background = new SolidColorBrush(Color.FromArgb(255, 244, 141, 142));

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            if (MySplitView.IsPaneOpen)
            {
                //TitleTextBlock.Text = "ZTasks";
                //double left = 20, top = 10, right = 160, bottom = 0;
                //TitleTextBlock.Margin = new Thickness(left, top, right, bottom);
            }
            else
            {
                //TitleTextBlock.Text = "";
                //double left = 0, top = 0, right = 10, bottom = 0;
                //TitleTextBlock.Margin = new Thickness(left, top, right, bottom);
            }
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            AddTaskClicked?.Invoke(this, e);
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = ListBox.SelectedItem as ListBoxItem;
            Home.Background = new SolidColorBrush(Colors.Transparent);
            MyFrame.BackStack.Clear();
            MyFrame.Navigate(typeof(HomePage), this, new SuppressNavigationTransitionInfo());
            if (Home.IsSelected)
            {
                HomeEvent?.Invoke();
            }

            else if (Today.IsSelected)
            {
                TodayEvent?.Invoke();
            }

            else if (Upcoming.IsSelected)
            {
                UpcomingEvent?.Invoke();
            }
            else if (Delayed.IsSelected)
            {
                DelayedEvent?.Invoke();
            }
            else if (AssignedToOthers.IsSelected)
            {
                AssignedToOthersEvent?.Invoke();
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            RefreshEventClicked.Invoke();
        }
    }
}

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

            if (Home.IsSelected)
            {
                MyFrame.BackStack.Clear();
                MyFrame.Navigate(typeof(HomePage), this, new SuppressNavigationTransitionInfo());

                //Title.Text = "Home";
            }

            else if (Today.IsSelected)
            {
                MyFrame.BackStack.Clear();
                MyFrame.Navigate(typeof(Today), this, new SuppressNavigationTransitionInfo());
                //Title.Text = "Today";
            }

            else if (Upcoming.IsSelected)
            {
                MyFrame.BackStack.Clear();
                MyFrame.Navigate(typeof(Upcoming), this, new SuppressNavigationTransitionInfo());
                //Title.Text = "Upcoming";

            }
            else if (Delayed.IsSelected)
            {
                MyFrame.BackStack.Clear();
                MyFrame.Navigate(typeof(Delayed), this, new SuppressNavigationTransitionInfo());
                //Title.Text = "Delayed";
            }
            else if (AssignedToOthers.IsSelected)
            {
                MyFrame.BackStack.Clear();
                MyFrame.Navigate(typeof(OthersTasks), this, new SuppressNavigationTransitionInfo());
                //Title.Text = "Assigned To Others";
            }
        }

        //public void SetBackground()
        //{
        //    Home.Background = new SolidColorBrush(Colors.Transparent);
        //    Today.Background = new SolidColorBrush(Colors.Transparent);
        //    Upcoming.Background = new SolidColorBrush(Colors.Transparent);
        //    Delayed.Background = new SolidColorBrush(Colors.Transparent);
        //    AssignedToOthers.Background = new SolidColorBrush(Colors.Transparent);

        //}

    }
}

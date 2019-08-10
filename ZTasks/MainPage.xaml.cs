﻿using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;
using ZTasks.Presentation.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZTasks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            Window.Current.SetTitleBar(trickyTitleBar);
            UserName.Text = "Prithvi Venu";
            MyFrame.Navigate(typeof(HomePage));

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            if (MySplitView.IsPaneOpen)
            {
                TitleTextBlock.Text = "ZTasks";
                double left = 20, top = 10, right = 160, bottom = 0;
                TitleTextBlock.Margin = new Thickness(left, top, right, bottom);
            }
            else
            {
                TitleTextBlock.Text = "";
                double left = 0, top = 0, right = 10, bottom = 0;
                TitleTextBlock.Margin = new Thickness(left, top, right, bottom);
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                MyFrame.Navigate(typeof(HomePage));
            }

            else if (Today.IsSelected)
            {
                MyFrame.Navigate(typeof(Today));

            }

            else if (Upcoming.IsSelected)
            {
                MyFrame.Navigate(typeof(Upcoming));

            }
            else if (Delayed.IsSelected)
            {
                MyFrame.Navigate(typeof(Delayed));

            }
            else if (AssignedToOthers.IsSelected)
            {
                MyFrame.Navigate(typeof(OthersTasks));

            }
        }

    }
}

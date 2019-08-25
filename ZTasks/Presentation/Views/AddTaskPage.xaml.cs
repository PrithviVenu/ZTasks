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

        public AddTaskPage()
        {
            this.InitializeComponent();
            subtasks = new ObservableCollection<ZTask>();

            subtasks.Add(new ZTask());
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
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TextBox b = (TextBox)sender;
                ZTask task1 = (ZTask)b.DataContext;
                task1.TaskTitle = b.Text;
                Debug.WriteLine(task1.TaskTitle);
                if (subtasks.Last() == task1)
                {
                    if (!b.Text.Equals(""))
                    {
                        subtasks.Add(new ZTask());
                    }
                }
                else
                {

                }

                //task1.AssignedBy = "101";

                //Debug.WriteLine(task1.AssignedBy, task1.AssignedBy);


            }

        }
        private void ShowCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // calendarPopup.IsOpen = true;
            CalendarPopup.IsOpen = !CalendarPopup.IsOpen;
        }

        private void ShowSubTaskCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // calendarPopup.IsOpen = true;
            CalendarPopup.IsOpen = !CalendarPopup.IsOpen;

        }
        public void ItemClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(SubTasksListView.SelectedIndex, "999999");
        }

        public void CollapseSlideInPane(object sender, RoutedEventArgs e)
        {
            CollapseClicked?.Invoke();
        }

        private void ItemPointerEntered(Object sender, PointerRoutedEventArgs e)

        {

        }

        private void ItemPointerExited(Object sender, PointerRoutedEventArgs e)
        {


        }

    }
}

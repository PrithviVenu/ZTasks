using System;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using ZTasks.Models;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ZTasks.Presentation.Views
{
    public sealed partial class CreateOrModifyUserControl : UserControl
    {
        public Models.ZTask Subtasks { get { return this.DataContext as Models.ZTask; } }
        public delegate void KeyEvent(object sender, KeyRoutedEventArgs e);
        public event KeyEvent EnterKeyDown;
        public delegate void TextBoxContextChanged(FrameworkElement sender,
     DataContextChangedEventArgs args);
        // public event TextBoxContextChanged TextContextChanged;
        string OldText = string.Empty;
        public delegate void DeleteButtonClick(object sender, RoutedEventArgs e);
        public event DeleteButtonClick DeleteButtonClicked;
        // AddTaskPage addTaskPage1;
        //public delegate void CalendarButtonClick(object sender, RoutedEventArgs e);
        //public event CalendarButtonClick CalendarButtonClicked;
        public Page page;
        public CreateOrModifyUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            OldText = SubTaskTitle.Text;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            string newText = SubTaskTitle.Text;
            if (string.IsNullOrEmpty(newText))
            {
                SubTaskTitle.Text = OldText;
            }
            //Compare OldText and newText here
        }
        internal void FocusTextBox()
        {
            SubTaskTitle.Focus(FocusState.Programmatic);
        }

        //private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        //{
        //    Flyout.ShowAt(SubTaskTitle);

        //    // Omitted Code: Insert code that does something whenever
        //    // the text changes...
        //}
        //private void InputTextBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var textBox = (TextBox)sender;
        //    textBox.Focus(FocusState.Programmatic);
        //}
        //private void TextBox_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        //{
        //    TextContextChanged?.Invoke(sender, args);
        //}

        public void SetEventPageReference(Page page)
        {
            this.page = page;
            CreateOrModifyTaskPage addTaskPage = (CreateOrModifyTaskPage)page;
            addTaskPage.ListViewClicked += ItemClick;
            // addTaskPage1 = addTaskPage;
        }
        public void ItemClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("UC");
        }

        public void PriorityClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem)sender;
            //Debug.WriteLine(item.Text, item.Name);
            ZTask task = (ZTask)item.DataContext;
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);

            if ((string)item.Tag == "2")
            {
                High.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));

                task.TaskDetails.Priority = 2;
            }
            else if ((string)item.Tag == "1")
            {
                Medium.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));

                task.TaskDetails.Priority = 1;

            }
            else if ((string)item.Tag == "0")

            {
                Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));

                task.TaskDetails.Priority = 0;

            }
            //  addTaskPage1.printpriority();

        }
        private void ShowSubTaskCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            SubTaskCalendarPopup.IsOpen = !SubTaskCalendarPopup.IsOpen;

            //CalendarButtonClicked?.Invoke(sender, e);

        }
        private void Box_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                EnterKeyDown?.Invoke(sender, e);
            }

        }
        public void DeleteSubTask(object sender, RoutedEventArgs e)
        {
            DeleteButtonClicked?.Invoke(sender, e);
        }
        //private void ItemPointerEntered(Object sender, PointerRoutedEventArgs e)

        //{
        //    SubTaskRecurring.Visibility = Visibility.Visible;
        //    SubTaskPriority.Visibility = Visibility.Visible;
        //    SubTaskDueDate.Visibility = Visibility.Visible;

        //}

        //private void ItemPointerExited(Object sender, PointerRoutedEventArgs e)
        //{
        //    SubTaskRecurring.Visibility = Visibility.Collapsed;
        //    SubTaskPriority.Visibility = Visibility.Collapsed;
        //    SubTaskDueDate.Visibility = Visibility.Collapsed;
        //}


    }

}

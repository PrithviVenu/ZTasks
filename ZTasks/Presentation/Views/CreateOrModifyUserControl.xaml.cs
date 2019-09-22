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
        string OldText = string.Empty;
        public delegate void DeleteButtonClick(object sender, RoutedEventArgs e);
        public event DeleteButtonClick DeleteButtonClicked;
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
                //Comparing OldText and newText 
                SubTaskTitle.Text = OldText;
            }
        }
        internal void FocusTextBox()
        {
            SubTaskTitle.Focus(FocusState.Programmatic);
        }

        public void SetEventPageReference(Page page)
        {
            this.page = page;
            CreateOrModifyTaskPage TaskPage = (CreateOrModifyTaskPage)page;
            TaskPage.UserControlAddEventTriggered -= AddEvent;
            TaskPage.UserControlAddEventTriggered += AddEvent;

        }

        public void AddEvent()
        {
            Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
            SubTaskPriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
        }

        public void PriorityClick(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = (MenuFlyoutItem)sender;
            ZTask task = (ZTask)item.DataContext;
            High.Background = new SolidColorBrush(Colors.Transparent);
            Low.Background = new SolidColorBrush(Colors.Transparent);
            Medium.Background = new SolidColorBrush(Colors.Transparent);

            if ((string)item.Tag == "2")
            {
                High.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                SubTaskPriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 217, 72, 59));
                task.TaskDetails.Priority = 2;
            }
            else if ((string)item.Tag == "3")
            {
                Medium.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                SubTaskPriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 93, 188, 210));
                task.TaskDetails.Priority = 3;

            }
            else if ((string)item.Tag == "4")

            {
                Low.Background = new SolidColorBrush(Color.FromArgb(255, 227, 227, 227));
                SubTaskPriorityText.Foreground = new SolidColorBrush(Color.FromArgb(255, 136, 136, 136));
                task.TaskDetails.Priority = 4;

            }

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



    }

}

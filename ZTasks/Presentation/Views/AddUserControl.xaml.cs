using System;
using System.Collections.Generic;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ZTasks.Presentation.Views
{
    public sealed partial class AddUserControl : UserControl
    {
        public Models.ZTask Subtasks { get { return this.DataContext as Models.ZTask; } }
        public delegate void KeyEvent(object sender, KeyRoutedEventArgs e);
        public event KeyEvent EnterKeyDown;
        public delegate void TextBoxContextChanged(FrameworkElement sender,
     DataContextChangedEventArgs args);
        //public event TextBoxContextChanged TextContextChanged;
        //    public delegate void TextBoxContextChanged(FrameworkElement sender,
        //DataContextChangedEventArgs args);
        //    public event TextBoxContextChanged TextContextChanged;
        //public delegate void CalendarButtonClick(object sender, RoutedEventArgs e);
        //public event CalendarButtonClick CalendarButtonClicked;
        public Page page;
        public AddUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();

        }

        internal void FocusTextBox()
        {
            SubTaskTitle.Focus(FocusState.Programmatic);
        }

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
            AddTaskPage addTaskPage = (AddTaskPage)page;
            addTaskPage.ListViewClicked += ItemClick;

        }
        public void ItemClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("UC");
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
                if (EnterKeyDown != null)
                {
                    EnterKeyDown?.Invoke(sender, e);


                }



            }

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

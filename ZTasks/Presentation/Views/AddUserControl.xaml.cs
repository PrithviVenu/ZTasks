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
        public Domain.Models.ZTask Subtasks { get { return this.DataContext as Domain.Models.ZTask; } }
        public delegate void KeyEvent(object sender, KeyRoutedEventArgs e);
        public event KeyEvent EnterKeyDown;
        public delegate void CalendarButtonClick(object sender, RoutedEventArgs e);
        public event CalendarButtonClick CalendarButtonClicked;
        public Page page;
        public AddUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();

        }

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
            CalendarButtonClicked?.Invoke(sender, e);

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

        private void ItemPointerEntered(Object sender, PointerRoutedEventArgs e)

        {

        }

        private void ItemPointerExited(Object sender, PointerRoutedEventArgs e)
        {


        }


    }
}

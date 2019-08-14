using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class HomePage : Page
    {
        private ObservableCollection<ZTask> tasks;

        public HomePage()
        {
            this.InitializeComponent();
            tasks = new ObservableCollection<ZTask>();
            tasks.Add(new ZTask { TaskId = 1, TaskTitle = "Learn C#", Assignee = "Siddharth", AssignedBy = "Prithvi Venu", AddedOn = System.DateTime.Now, DueDate = System.DateTime.Now, Priority = "High", RemindOn = System.DateTime.Now, ParentTaskId = "1001" });
        }
    }
}

using SQLite;
using System;
using System.Collections.ObjectModel;
using ZTasks.NotificationCenter;
using ZTasks.Utility;

namespace ZTasks.Models
{
    public class ZTask : NotifyPropertyChangedBase
    {

        private TaskAssignment ZAssignment;
        private TaskDetail ZTaskDetail;
        private ObservableCollection<ZTask> zTasks;
        public ZTask()
        {
            ZAssignment = new TaskAssignment();
            ZTaskDetail = new TaskDetail();
            zTasks = new ObservableCollection<ZTask>();
        }


        public TaskAssignment Assignment
        {
            get
            {
                return ZAssignment;
            }

            set
            {
                this.SetProperty(ref ZAssignment, value);
            }

        }
        public TaskDetail TaskDetails
        {
            get
            {
                return ZTaskDetail;
            }

            set
            {
                this.SetProperty(ref ZTaskDetail, value);
            }

        }

        public ObservableCollection<ZTask> SubTasks
        {
            get
            {
                return zTasks;
            }

            set
            {
                this.SetProperty(ref zTasks, value);
            }
        }


    }


}
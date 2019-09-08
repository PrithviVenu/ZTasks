using SQLite;
using System;
using ZTasks.NotificationCenter;

namespace ZTasks.Models
{
    public class ZTask : NotifyPropertyChangedBase
    {
        //private string ZTaskId;
        //private string ZTaskTitle;
        //private DateTimeOffset? ZCreatedTime;
        //private DateTimeOffset? ZDueDate;
        //private DateTimeOffset? ZModifiedDate;
        //private int ZPriority;
        //private int ZTaskStatus;
        //private DateTimeOffset? ZRemindOn;
        //private string ZDescription;
        //private string ZParentTaskId;
        private TaskAssignment ZAssignment;
        private TaskDetail ZTaskDetail;
        
        public ZTask()
        {
            ZAssignment = new TaskAssignment();
            ZTaskDetail = new TaskDetail();
        }


        //[PrimaryKey]
        //public string TaskId
        //{
        //    get
        //    {
        //        return ZTaskId;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZTaskId, value);
        //    }
        //}
        //public string TaskTitle
        //{
        //    get
        //    {
        //        return ZTaskTitle;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZTaskTitle, value);
        //    }
        //}

        //public DateTimeOffset? CreatedTime
        //{
        //    get
        //    {
        //        return ZCreatedTime;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZCreatedTime, value);
        //    }
        //}
        //public DateTimeOffset? DueDate
        //{
        //    get
        //    {
        //        return ZDueDate;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZDueDate, value);
        //    }
        //}
        //public DateTimeOffset? ModifiedDate
        //{
        //    get
        //    {
        //        return ZModifiedDate;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZModifiedDate, value);
        //    }
        //}
        //public int Priority
        //{
        //    get
        //    {
        //        return ZPriority;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZPriority, value);
        //    }
        //}

        //public int TaskStatus
        //{
        //    get
        //    {
        //        return ZTaskStatus;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZTaskStatus, value);
        //    }
        //}
        //public DateTimeOffset? RemindOn
        //{
        //    get
        //    {
        //        return ZRemindOn;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZRemindOn, value);
        //    }
        //}
        //public string Description
        //{
        //    get
        //    {
        //        return ZDescription;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZDescription, value);
        //    }
        //}


        //public string ParentTaskId
        //{
        //    get
        //    {
        //        return ZParentTaskId;
        //    }

        //    set
        //    {
        //        this.SetProperty(ref ZParentTaskId, value);
        //    }
        //}
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
    }


}
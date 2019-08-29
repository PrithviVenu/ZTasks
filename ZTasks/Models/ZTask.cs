using SQLite;
using System;
using ZTasks.NotificationCenter;

namespace ZTasks.Models
{
    public class ZTask : INotifyPropertyChangedBase
    {
        private string ZTaskId;
        private string ZTaskTitle;
        private string ZAssigneeId;
        private string ZAssignedById;
        private string ZAssigneeName;
        private string ZAssignedByName;
        private DateTime ZCreatedTime;
        private DateTime ZDueDate;
        private DateTime ZModifiedDate;
        private int ZPriority;
        private int ZTaskStatus;
        private DateTime ZRemindOn;
        private string ZParentTaskId;

        [PrimaryKey]
        public string TaskId
        {
            get
            {
                return ZTaskId;
            }

            set
            {
                this.SetProperty(ref ZTaskId, value);
            }
        }
        public string TaskTitle
        {
            get
            {
                return ZTaskTitle;
            }

            set
            {
                this.SetProperty(ref ZTaskTitle, value);
            }
        }
        public string AssigneeId
        {
            get
            {
                return ZAssigneeId;
            }

            set
            {
                this.SetProperty(ref ZAssigneeId, value);
            }
        }
        public string AssignedById
        {
            get
            {
                return ZAssignedById;
            }

            set
            {
                this.SetProperty(ref ZAssignedById, value);
            }
        }

        public string AssigneeName
        {
            get
            {
                return ZAssigneeName;
            }

            set
            {
                this.SetProperty(ref ZAssigneeName, value);
            }
        }
        public string AssignedByName
        {
            get
            {
                return ZAssignedByName;
            }

            set
            {
                this.SetProperty(ref ZAssignedByName, value);
            }
        }
        public DateTime CreatedTime
        {
            get
            {
                return ZCreatedTime;
            }

            set
            {
                this.SetProperty(ref ZCreatedTime, value);
            }
        }
        public DateTime DueDate
        {
            get
            {
                return ZDueDate;
            }

            set
            {
                this.SetProperty(ref ZDueDate, value);
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return ZModifiedDate;
            }

            set
            {
                this.SetProperty(ref ZModifiedDate, value);
            }
        }
        public int Priority
        {
            get
            {
                return ZPriority;
            }

            set
            {
                this.SetProperty(ref ZPriority, value);
            }
        }

        public int TaskStatus
        {
            get
            {
                return ZTaskStatus;
            }

            set
            {
                this.SetProperty(ref ZTaskStatus, value);
            }
        }
        public DateTime RemindOn
        {
            get
            {
                return ZRemindOn;
            }

            set
            {
                this.SetProperty(ref ZRemindOn, value);
            }
        }

        public string ParentTaskId
        {
            get
            {
                return ZParentTaskId;
            }

            set
            {
                this.SetProperty(ref ZParentTaskId, value);
            }
        }

    }


}

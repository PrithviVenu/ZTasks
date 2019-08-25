using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.NotificationCenter;

namespace ZTasks.Domain.Models
{
    class ZTask : INotifyPropertyChangedBase
    {
        private int ZTaskId;
        private string ZTaskTitle;
        private string ZAssignee;
        private string ZAssignedBy;
        private int ZCreatedTime;
        private int ZDueDate;
        private int ZModifiedDate;
        private Priority ZPriority;
        private DateTime ZRemindOn;
        private string ZGroupId;
        private string ZProjectId;
        private string ZParentTaskId;

        [PrimaryKey, AutoIncrement]
        public int TaskId
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
        public string Assignee
        {
            get
            {
                return ZAssignee;
            }

            set
            {
                this.SetProperty(ref ZAssignee, value);
            }
        }
        public string AssignedBy
        {
            get
            {
                return ZAssignedBy;
            }

            set
            {
                this.SetProperty(ref ZAssignedBy, value);
            }
        }
        public int CreatedTime
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
        public int DueDate
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
        public int ModifiedDate
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
        public Priority Priority
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
        public string GroupId
        {
            get
            {
                return ZGroupId;
            }

            set
            {
                this.SetProperty(ref ZGroupId, value);
            }
        }
        public string ProjectId
        {
            get
            {
                return ZProjectId;
            }

            set
            {
                this.SetProperty(ref ZProjectId, value);
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

    enum Priority
    {
        Low,
        Medium,
        High
    }
}

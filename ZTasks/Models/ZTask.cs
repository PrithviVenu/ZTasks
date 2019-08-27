using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.NotificationCenter;
using ZTasks.Utility;
namespace ZTasks.Models
{
    public class ZTask : INotifyPropertyChangedBase
    {
        private string ZTaskId;
        private string ZTaskTitle;
        private string ZAssignee;
        private string ZAssignedBy;
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

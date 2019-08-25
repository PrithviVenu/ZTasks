using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.NotificationCenter;
using ZTasks.Domain.Utility;
namespace ZTasks.Domain.Models
{
    public class ZTask : INotifyPropertyChangedBase
    {
        private string ZTaskId;
        private string ZTaskTitle;
        private string ZAssignee;
        private string ZAssignedBy;
        private int ZCreatedTime;
        private int ZDueDate;
        private int ZModifiedDate;
        private int ZPriority;
        private int ZRemindOn;
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
        public int RemindOn
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

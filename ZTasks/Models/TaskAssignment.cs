using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.NotificationCenter;

namespace ZTasks.Models
{
    public class TaskAssignment : NotifyPropertyChangedBase
    {
        private string ZTaskId;
        private string ZAssignedById;
        private string ZAssignedByName;
        private string ZAssigneeId;
        private string ZAssigneeName;

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
    }
}

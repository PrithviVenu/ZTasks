using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.Models
{
    class ZTask
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Assignee { get; set; }
        public string AssignedBy { get; set; }
        public int CreatedTime { get; set; }
        public int DueDate { get; set; }
        public int ModifiedDate { get; set; }
        public Priority Priority { get; set; }
        public DateTime RemindOn { get; set; }
        public string GroupId { get; set; }
        public string ProjectId { get; set; }
        public string ParentTaskId { get; set; }

    }

    enum Priority
    {
        Low,
        Medium,
        High
    }
}

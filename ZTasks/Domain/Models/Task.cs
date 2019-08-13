using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.Models
{
    class Task
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Assignee { get; set; }
        public string AssignedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public DateTime RemindOn { get; set; }
        public string ParentTaskId { get; set; }
    }
}

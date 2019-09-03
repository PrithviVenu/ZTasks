using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Models
{
    class TaskUtilityModel
    {
        public string TaskId { get; set; }
        public string TaskTitle { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public int Priority { get; set; }
        public int TaskStatus { get; set; }
        public DateTimeOffset? RemindOn { get; set; }
        public string Description { get; set; }
        public string ParentTaskId { get; set; }
        public string AssignedById { get; set; }
        public string AssigneeId { get; set; }
        public string AssignedByName { get; set; }
        public string AssigneeName { get; set; }
    }
}

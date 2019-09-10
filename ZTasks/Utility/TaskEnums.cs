using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Utility
{
    public enum FilterOperation : int
    {
        open,
        closed,
        Low,
        Medium,
        High
    }
    public enum SortOperation
    {
        DueDateAscending,
        DueDateDescending,
        ModifiedDateAscending,
        ModifiedDateDescending
    }

    public enum TaskOperation
    {
        Add,
        Modify
    }


    public enum TaskView
    {
        Home,
        Today,
        Upcoming,
        Delayed,
        AssignedToOthers
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Utility
{
  public  enum Priority : int
    {
        Low,
        Medium,
        High
    }
    public enum Status
    {
        open,
        closed
    }

    public enum TaskOperation
    {
        Add,
        Modify
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Models;

namespace ZTasks.Data.DMHandlerContract
{
    public interface IAddTasksDBHandlerContract
    {
        Task AddOrModifyTasks(List<TaskUtilityModel> utility);
    }
}

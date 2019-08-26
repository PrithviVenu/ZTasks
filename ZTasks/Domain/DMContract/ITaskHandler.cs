using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Domain.Models;
namespace ZTasks.Domain.DMContract
{
    interface ITaskHandler
    {
        Task AddTaskToDb(ObservableCollection<ZTask> task, ZTask parentZtask)
;

    }
}

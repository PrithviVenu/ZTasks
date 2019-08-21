using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTasks.Data;
using ZTasks.Domain.DMContract;

namespace ZTasks.Domain.Usecase
{
    class AddTaskUseCase : UseCaseBase
    {

        public override void Execute()
        {
            ITaskHandler taskHandler = new TaskDAO();
        }

        protected override async Task ActionAsync()
        {
            await ActionAsync();
        }
    }
}

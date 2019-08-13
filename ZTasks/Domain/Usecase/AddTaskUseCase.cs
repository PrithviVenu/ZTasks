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
            ITaskHandlerInterface taskHandler = new TaskDAO();

        }

        internal override async Task Action()
        {
            await Action();

        }
    }
}

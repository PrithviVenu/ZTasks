﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTasks.Domain.Usecase
{
    public abstract class UseCaseBase
    {
        protected bool GetIfAvailableInCache()
        {
            return false;
        }
        protected abstract Task ActionAsync();
        public async void Execute()
        {
            if (GetIfAvailableInCache())
            {
                return;
            }
            try
            {
                await Task.Run(() => ActionAsync());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
        }
    }
}

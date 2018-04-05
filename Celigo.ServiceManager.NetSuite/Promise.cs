using System;
using System.Collections.Generic;
using System.Text;

namespace Celigo.ServiceManager.NetSuite
{
    public class Promise<T>
    {
        private List<Func<T, object>> thenHandlers = new List<Func<T, object>>(1);

        public Promise<TResult> Then<TResult>(Func<T, TResult> handler) where TResult : class
        {
            this.thenHandlers.Add(handler);
            return new Promise<TResult>();
        }
    }
}

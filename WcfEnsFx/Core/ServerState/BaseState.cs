using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    abstract class BaseState<T> where T : class
    {
        readonly IServiceOperation<T> service;

        protected IServiceOperation<T> Service
        {
            get { return service; }
        }

        protected BaseState(IServiceOperation<T> service)
        {
            if (service == null) throw new ArgumentNullException();

            this.service = service;
        }

        protected virtual void OnError()
        { }


        protected virtual void OnError(string msg)
        {
            Debug.WriteLine(msg);
        }

        internal virtual void Create()
        {
            OnError();
        }

        internal virtual void Open()
        {
            OnError();
        }

        internal virtual void Close()
        {
            OnError();
        }

        
    }
}

using System;

namespace WcfEnsFx
{
    abstract class ServerState<T> : StateBase where T : class 
    {
        protected ServiceWrapper<T> ServiceWrapper;

        protected ServerState(ServiceWrapper<T> serviceWrapper)
        {
            if (serviceWrapper == null) throw new ArgumentNullException();

            ServiceWrapper = serviceWrapper;
        }

        internal virtual void Create()
        {
            ShowError();
        }

        internal virtual void Open()
        {
            ShowError();
        }

        internal virtual void Close()
        {
            ShowError();
        }
    }
}

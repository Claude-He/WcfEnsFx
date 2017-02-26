using System.ServiceModel;

namespace WcfEnsFx
{
    class OpenedState<T> : ServerState<T> where T : class 
    {
        internal OpenedState(ServiceWrapper<T> serviceWrapper)
            : base(serviceWrapper)
        {}

        internal override void Close()
        {
            if (ServiceWrapper.State == CommunicationState.Opened)
                ServiceWrapper.CurrentState = ServiceWrapper.Close() ? 
                    ServiceWrapper.ClosedState : ServiceWrapper.FaultedState;
        }
    }
}

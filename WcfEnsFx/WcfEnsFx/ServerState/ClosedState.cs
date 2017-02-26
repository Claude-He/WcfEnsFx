using System.ServiceModel;

namespace WcfEnsFx
{
    class ClosedState<T> : ServerState<T> where T : class 
    {
        internal ClosedState(ServiceWrapper<T> serviceWrapper)
            : base(serviceWrapper)
        {}

        internal override void Open()
        {
            if (ServiceWrapper.State == CommunicationState.Closed)
                ServiceWrapper.CurrentState = ServiceWrapper.Open() ? 
                    ServiceWrapper.OpenedState : ServiceWrapper.FaultedState;
        }
    }
}

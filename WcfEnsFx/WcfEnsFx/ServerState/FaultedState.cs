using System.ServiceModel;

namespace WcfEnsFx
{
    class FaultedState<T> : ServerState<T> where T : class 
    {
        internal FaultedState(ServiceWrapper<T> serviceWrapper)
            : base(serviceWrapper)
        {}

        internal override void Open()
        {
            if (ServiceWrapper.State == CommunicationState.Faulted || ServiceWrapper.State == CommunicationState.Closed)
                ServiceWrapper.CurrentState = ServiceWrapper.Open() ? 
                    ServiceWrapper.OpenedState : ServiceWrapper.FaultedState;
        }
    }
}

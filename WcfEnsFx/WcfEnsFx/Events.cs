using System.ServiceModel;

namespace WcfEnsFx
{
    public delegate void ServiceStateChangedEventHandler(CommunicationState currentState);

    public delegate void SubscriptionStateChangedEventHandler(SubscriberState currentState); 
}

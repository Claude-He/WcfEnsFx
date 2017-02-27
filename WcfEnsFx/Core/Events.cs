using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    public delegate void ServiceStateChanged(CommunicationState currentState);

    public delegate void SubscriptionStateChanged(SubscriberState currentState);

    public enum SubscriberState
    {
        Disconnecting,
        Disconnected,
        Connecting,
        Connected,
        Subscribed,
        Faulted
    }
}

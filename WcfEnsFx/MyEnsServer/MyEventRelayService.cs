using System;
using System.ServiceModel;
using MyContract;
using WcfEnsFx.Core;

namespace MyEnsServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class MyEventRelayService : EventRelayService<IMyEvent>, IMyEvent
    {
        public void DemoEvent(string eventMessage)
        {
            RelayEvent(eventMessage);
        }

        public void DemoEvent(string eventMessage, int intParam)
        {
            RelayEvent(eventMessage, intParam);
        }
    }
}

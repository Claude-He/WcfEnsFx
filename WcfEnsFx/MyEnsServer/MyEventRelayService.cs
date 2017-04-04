using System;
using System.ServiceModel;
using MyContract;
using WcfEnsFx.Core;

namespace MyEnsServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class MyEventRelayService : EventRelayService<IMyEvent>, IMyEvent
    {
        public void DemoEvent(string strArg)
        {
            RelayEvent(strArg);
        }

        public void DemoEvent(string strArg, int intArg)
        {
            RelayEvent(strArg, intArg);
        }
    }
}

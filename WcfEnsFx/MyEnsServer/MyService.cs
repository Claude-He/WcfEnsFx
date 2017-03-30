using MyContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfEnsFx.Core;

namespace MyEnsServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class MyService : SubscriptionServer<IMyEvent>, IMyService
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}

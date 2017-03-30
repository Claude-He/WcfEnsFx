using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    class Service<S, E, P> 
        where S : SubscriptionServer<E>//, IEnsSubscription
        where E : class
        where P: PublishServer<E>
    {
       
    }
}

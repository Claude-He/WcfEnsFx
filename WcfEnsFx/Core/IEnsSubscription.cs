using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    [ServiceContract]
    public interface IEnsSubscription
    {
        [OperationContract]
        void Subscribe(string subscriberName, string eventName);
               
        [OperationContract]
        void Unsubscribe(string eventName);       
    }
}

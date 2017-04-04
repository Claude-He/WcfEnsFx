using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    internal interface ISubscriberCollection<T>
    {
        T[] GetSubscribers(string eventName);

        void RemoveSubscriber(T subscriber);

        //void RemoveAllSubscribers();
    }
    
}

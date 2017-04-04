using System.ServiceModel;

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

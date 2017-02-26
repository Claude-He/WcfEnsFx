using System.ServiceModel;

namespace WcfEnsFx
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        void Subscribe(string subscriberName, string eventOperation);

        [OperationContract(IsOneWay = false)]
        bool IsSubscribed(string eventOperation);

        [OperationContract]
        void Unsubscribe(string eventOperation);
        
        [OperationContract(IsOneWay = false)]
        bool IsConnected();
    }
}

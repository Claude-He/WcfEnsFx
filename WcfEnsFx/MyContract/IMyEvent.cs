using System.ServiceModel;

namespace MyContract
{
    [ServiceContract(Namespace = "https://github.com/Claude-He/WcfEnsFx")]
    public interface IMyEvent
    {
        [OperationContract]
        void DemoEvent(string eventMessage);

        [OperationContract(Name = "DemoEventWithInt")]
        void DemoEvent(string eventMessage, int intParam);
    }
}

using System.ServiceModel;

namespace MyContract
{
    [ServiceContract(Namespace = "https://github.com/Claude-He/WcfEnsFx")]
    public interface IMyEvent
    {
        [OperationContract]
        void DemoEvent(string strArg);

        [OperationContract(Name = "DemoEventWithInt")]
        void DemoEvent(string strArg, int intArg); 
    }
}

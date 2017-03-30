using System;
using System.ServiceModel;
using WcfEnsFx.Core;

namespace MyContract
{
    [ServiceContract(CallbackContract = typeof(IMyEvent), 
        Namespace = "https://github.com/Claude-He/WcfEnsFx")]
    public interface IMyService : IEnsSubscription
    {
        [OperationContract]
        DateTime GetTime();
    }
}

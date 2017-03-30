using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    interface IServiceOperation<T> where T : class
    {
        CommunicationState State { get; }

        void OpenService();

        void CloseService();
    }
}

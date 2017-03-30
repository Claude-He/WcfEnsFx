using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    public class EnsService<TS, TI, TP, TE>
        where TS : SubscriptionServer<TE>, IEnsSubscription, TI, new()
        where TI : IEnsSubscription
        where TP : EventRelayService<TE>, TE, new()
        where TE : class
    {
        public event ServiceStateChangedEventHandler PublishServiceStateChanged;

        public event ServiceStateChangedEventHandler SubscriptionServiceStateChanged;

        //ServiceWrapper<TP, TE> publishSvcHost = new ServiceWrapper<TP, TE>();
        //ServiceWrapper<TS, TI> subscriptionSvcHost = new ServiceWrapper<TS, TI>();

        public CommunicationState SubscriptionServerState => subscriptionHost.State;

        public CommunicationState PublishServerState => publishHost.State;

        private readonly ServiceHost subscriptionHost;

        private readonly ServiceHost publishHost;
        
        public EnsService()
        {
            var subscriptionServerInstance = new TS();

            subscriptionHost = new ServiceHost(subscriptionServerInstance);
            RegistrEvents(subscriptionHost, OnSubscriptionServiceStateChanged);

            var tp = new TP
            {
                SubscriptionServer = subscriptionServerInstance
            };

            publishHost = new ServiceHost(tp);
            RegistrEvents(publishHost, OnPublishServiceStateChanged);
        }

        private static void RegistrEvents(ServiceHost host, EventHandler handler)
        {
            host.Opened += handler;
            host.Opening += handler;
            host.Closing += handler;
            host.Closed += handler;
            host.Faulted += handler;
        }

        public ServiceEndpoint AddSubscriptionServiceEndpoint(Binding binding, string address)
        {
            return subscriptionHost.AddServiceEndpoint(typeof(TI), binding, address);
        }

        public ServiceEndpoint AddPublishServiceEndpoint(Binding binding, string address)
        {
            return publishHost.AddServiceEndpoint(typeof(TE), binding, address);
        }

        public void OpenSubscriptionService()
        {
            subscriptionHost.Open();
        }

        public void CloseSubscriptionService()
        {
            subscriptionHost.Close();
        }

        public void OpenPublishService()
        {

            publishHost.Open();
        }

        public void ClosePublishService()
        {
            publishHost.Close();
        }


        protected void OnSubscriptionServiceStateChanged(object sender, EventArgs e)
        {
            SubscriptionServiceStateChanged?.Invoke(subscriptionHost.State);
        }

        protected void OnPublishServiceStateChanged(object sender, EventArgs e)
        {
            PublishServiceStateChanged?.Invoke(publishHost.State);
        }
    }
}

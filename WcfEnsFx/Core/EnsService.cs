using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfEnsFx.Core;

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
   
        public CommunicationState SubscriptionServerState => SubscriptionHost.State;

        public CommunicationState PublishServerState => PublishHost.State;

        private ServiceHost SubscriptionHost { get; set; }

        private ServiceHost PublishHost { get; set; }

        public EnsService()
        {
            CreateSubscriptionServiceHost();

            CreatePublishServiceHost();
        }

        #region Programmatically add End Point to the two service hosts
        // Overload more if needed...
        public ServiceEndpoint AddSubscriptionServiceEndpoint(Binding binding, string address)
        {
            return SubscriptionHost.AddServiceEndpoint(typeof(TI), binding, address);
        }

        public ServiceEndpoint AddPublishServiceEndpoint(Binding binding, string address)
        {
            return PublishHost.AddServiceEndpoint(typeof(TE), binding, address);
        }


        #endregion

        public void CreateSubscriptionServiceHost()
        {
            if (!AbleToCreateHost(SubscriptionHost))
            {
                throw new InvalidOperationException();
            }

            SubscriptionHost = new ServiceHost(new TS());
            RegistrEvents(SubscriptionHost, OnSubscriptionServiceStateChanged);
        }

        public void CreatePublishServiceHost()
        {
            if (!AbleToCreateHost(PublishHost))
            {
                throw new InvalidOperationException();
            }

            if (!IsSubscriptionServiceWorkable())
            {
                throw new InvalidOperationException("");
            }

            var tp = new TP
            {
                SubscriptionServer = (TS)SubscriptionHost.SingletonInstance
            };

            PublishHost = new ServiceHost(tp);
            RegistrEvents(PublishHost, OnPublishServiceStateChanged);
        }

        private bool IsSubscriptionServiceWorkable()
        {
            return SubscriptionServerState == CommunicationState.Created ||
                   SubscriptionServerState == CommunicationState.Opened ||
                   SubscriptionServerState == CommunicationState.Opening;
        }

        private static bool AbleToCreateHost(ICommunicationObject host)
        {
            return host == null ||
                   host.State == CommunicationState.Faulted ||
                   host.State == CommunicationState.Closed ||
                   host.State == CommunicationState.Closing;
        }

        private static bool IsServiceHostWorking(ICommunicationObject host)
        {
            return host != null && (host.State == CommunicationState.Opened || host.State == CommunicationState.Opening);
        }

        private static void RegistrEvents(ICommunicationObject host, EventHandler handler)
        {
            host.Opened += handler;
            host.Opening += handler;
            host.Closing += handler;
            host.Closed += handler;
            host.Faulted += handler;
        }

        private static void UnregistrEvents(ICommunicationObject host, EventHandler handler)
        {
            host.Opened -= handler;
            host.Opening -= handler;
            host.Closing -= handler;
            host.Closed -= handler;
            host.Faulted -= handler;
        }

        public void OpenSubscriptionService()
        {
            SubscriptionHost.Open();
        }

        public void CloseSubscriptionService()
        {
            SubscriptionHost.Close();
            UnregistrEvents(SubscriptionHost, OnSubscriptionServiceStateChanged);

            ((TS) SubscriptionHost.SingletonInstance).RemoveAllSubscribers();

            if (PublishServerState == CommunicationState.Opened ||
                PublishServerState == CommunicationState.Opening)
            {
                ClosePublishService();
            }
        }

        public void OpenPublishService()
        {
            if (!IsServiceHostWorking(SubscriptionHost))
            {
                //It's meaningless to open publish service if related subcription service is not working.
                //throw new InvalidOperationException();
            }

            PublishHost.Open();
        }

        public void ClosePublishService()
        {
            PublishHost.Close();

            UnregistrEvents(PublishHost, OnPublishServiceStateChanged);
        }


        protected void OnSubscriptionServiceStateChanged(object sender, EventArgs e)
        {
            SubscriptionServiceStateChanged?.Invoke(SubscriptionHost.State);
        }

        protected void OnPublishServiceStateChanged(object sender, EventArgs e)
        {
            PublishServiceStateChanged?.Invoke(PublishHost.State);
        }
    }
}

using System.ServiceModel;

namespace WcfEnsFx
{
    /// <summary>
    /// This class servers as the context used by state-pattern classes of subscriptions.
    /// For the tricks behind, see State-Pattern.
    /// </summary>
    /// <typeparam name="TS">Type of subscription that implements service contract.</typeparam>
    /// <typeparam name="T">Subscription callback(Event) contract.</typeparam>
    class SubscriptionClientProxyWrapper<TS, T> : ISubscription
        where TS : class
        where T : class 
    {
        private readonly T callbackInstance;
        
        private SubscriptionClientProxy<TS> subscriptionProxy;

        private readonly object locker = new object();

        private bool isConnecting;

        private bool isDisconnecting;

        internal CommunicationState State
        {
            get
            {
                return (subscriptionProxy == null) ? CommunicationState.Closed : subscriptionProxy.State;
            }
        }

        internal SubscriptionClientProxyWrapper(T callbackInstance)
        {
            this.callbackInstance = callbackInstance;
        }
        
        public void Connect()
        {
            if (isConnecting) return;

            lock (locker)
            {
                try
                {
                    isConnecting = true;

                    var callbackObject = new InstanceContext(callbackInstance);

                    subscriptionProxy = new SubscriptionClientProxy<TS>(callbackObject);

                    subscriptionProxy.Open();
                }
                finally
                {
                    isConnecting = false;
                }
            }
        }

        public void Disconnect()
        {
            if (isDisconnecting) return;

            lock (locker)
            {
                try
                {
                    isDisconnecting = true;

                    subscriptionProxy.Close();
                }
                finally
                {
                    isDisconnecting = false;
                }
            }
        }

        public void Subscribe(string subscriberName, string eventOperation)
        {
            lock (locker)
            {
                subscriptionProxy.Invoke(MethodNames.Subscribe, subscriberName, eventOperation);
            }
        }

        public bool IsSubscribed(string eventOperation)
        {
            lock (locker)
            {
                object isSubscribed = false;

                subscriptionProxy.Invoke(ref isSubscribed, MethodNames.IsSubscribed, eventOperation);

                return (bool)isSubscribed;
            }
        }
        
        public bool IsConnected()
        {
            lock (locker)
            {
                object isConnected = false;

                subscriptionProxy.Invoke(ref isConnected, MethodNames.IsConnected);

                return (bool)isConnected;
            }
        }

        public void Unsubscribe(string eventOperation)
        {
            lock (locker)
            {
                subscriptionProxy.Invoke(MethodNames.Unsubscribe, eventOperation);
            }
        }

        public bool Invoke(ref object returnValue, string methodName, params object[] args)
        {
            lock (locker)
            {
                subscriptionProxy.Invoke(ref returnValue, methodName, args);

                return true;
            }
        }

        public bool Invoke(string methodName, params object[] args)
        {
            lock (locker)
            {
                subscriptionProxy.Invoke(methodName, args);

                return true;
            }
        }
    }
}

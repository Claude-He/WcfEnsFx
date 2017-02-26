using System;
using System.ServiceModel;

namespace WcfEnsFx
{
    /// <summary>
    /// Wrapper of publish and subscription service.
    /// </summary>
    /// <typeparam name="TP">Type of publish that implements Event contract.</typeparam>
    /// <typeparam name="TS">Type of subscription that implements service contract.</typeparam>
    /// <typeparam name="T">Subscription callback(Events) contract.</typeparam>
    public class ServiceHelper<TP, TS, T> 
        where TP : PublishService<T>, T
        where TS : SubscriptionManager<T>, ISubscriptionService
        where T : class
    {
        public event ServiceStateChangedEventHandler OnPublishServiceStateChanged;

        public event ServiceStateChangedEventHandler OnSubscriptionServiceStateChanged;

        public CommunicationState PublishServiceState
        {
            get { return publishSvcHost.State; }
        }

        public CommunicationState SubscriptionServiceState
        {
            get { return subscriptionSvcHost.State; }
        }

        private readonly ServiceWrapper<TP> publishSvcHost = new ServiceWrapper<TP>();

        readonly ServiceWrapper<TS> subscriptionSvcHost = new ServiceWrapper<TS>();

        public ServiceHelper()
        {
            publishSvcHost.StateChanged += PublishServiceStateChanged;

            subscriptionSvcHost.StateChanged += SubscriptionServiceStateChanged;
        }

        public void OpenPublishService()
        {
            publishSvcHost.OpenService();
        }

        public void ClosePublishService()
        {
            publishSvcHost.CloseService();
        }
         
        public void OpenSubscriptionService()
        {
            subscriptionSvcHost.OpenService();
        }

        public void CloseSubscriptionService()
        {
            subscriptionSvcHost.CloseService();
        }

        /// <summary>
        /// Raise event to every subscribers of specified event.
        /// </summary>
        /// <param name="eventOperation">Name of event to be broadcasted.</param>
        /// <param name="args">args</param>
        public void BroadcastLocalEvent(string eventOperation, params object[] args)
        {
            if (string.IsNullOrEmpty(eventOperation)) throw new ArgumentNullException("eventOperation");

            if (subscriptionSvcHost.State == CommunicationState.Opened)
            {
                PublishService<T>.BroadcastLocalEvent(eventOperation, args);
            }
        }

        /// <summary>
        /// Raise an event (with NO return value) to a target subscriber.
        /// The eventOperation is better to be an One-Way call for fire-and-forget operation.
        /// </summary>
        /// <param name="targetSubscriber">The specified target subscriber.</param>
        /// <param name="eventOperation">Name of designated event to be raised.</param>
        /// <param name="args">args</param>
        public void RaiseEvent(T targetSubscriber, string eventOperation, params object[] args)
        {
            if (targetSubscriber == null) throw new ArgumentNullException("targetSubscriber");
            if (string.IsNullOrEmpty(eventOperation)) throw new ArgumentNullException("eventOperation");

            if (subscriptionSvcHost.State == CommunicationState.Opened)
            {
                PublishService<T>.RaiseLocalEvent(targetSubscriber, eventOperation, args);
            }
        }

        /// <summary>
        /// Raise event (with return value) to a target subscriber.
        /// The eventOperation is better to be a request-reply operation.
        /// </summary>
        /// <param name="returnValue">Return value.</param>
        /// <param name="targetSubscriber">The specified target subscriber.</param>
        /// <param name="eventOperation">Name of designated event to be raised.</param>
        /// <param name="args">args</param>
        public void RaiseEvent(ref object returnValue, T targetSubscriber, string eventOperation, params object[] args)
        {
            if (targetSubscriber == null) throw new ArgumentNullException("targetSubscriber");
            if (string.IsNullOrEmpty(eventOperation)) throw new ArgumentNullException("eventOperation");

            if (subscriptionSvcHost.State == CommunicationState.Opened)
            {
                PublishService<T>.RaiseLocalEvent(ref returnValue, targetSubscriber, eventOperation, args);
            }
        }

        void PublishServiceStateChanged(CommunicationState currentState)
        {
            if (OnPublishServiceStateChanged != null)
                OnPublishServiceStateChanged(currentState);
        }

        void SubscriptionServiceStateChanged(CommunicationState currentState)
        {
            if (OnSubscriptionServiceStateChanged != null)
                OnSubscriptionServiceStateChanged(currentState);
        }
    }
}

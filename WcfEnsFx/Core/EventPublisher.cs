using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    public abstract class EventPublisher<T> where T : class
    {
        private ISubscriberCollection<T> SubscriptionManager { get; }

        protected EventPublisher(SubscriptionServer<T> subscriptionManager)
        {
            if (null == subscriptionManager)
            {
                throw new ArgumentNullException(nameof(subscriptionManager));
            }

            SubscriptionManager = subscriptionManager;
        }

        public void BroadcastLocalEvent(string eventName, params object[] args)
        {
            RaiseEvent(eventName, args);
        }
                
        void RaiseEvent(string eventName, object[] args)
        {
            var subscribers = SubscriptionManager.GetSubscribers(eventName);

            PublishEvent(subscribers, eventName, args);
        }

       
        void PublishEvent(T[] subscribers, string eventName, object[] args)
        {
            Debug.Assert(subscribers != null);

            WaitCallback fire = subscriber => Invoke(subscriber as T, eventName, args);

            Action<T> queueUp = subscriber => ThreadPool.QueueUserWorkItem(fire, subscriber);

            Array.ForEach(subscribers, queueUp);
        }

        void Invoke(T subscriber, string methodName, object[] args)
        {
            Debug.Assert(subscriber != null);

            var methodInfo = Utils.GetMethod(typeof(T), methodName, args);

            try
            {
                methodInfo.Invoke(subscriber, args);
            }
            catch //(Exception e)
            {
                SubscriptionManager.RemoveSubscriber(subscriber);
            }
        }
    }
}

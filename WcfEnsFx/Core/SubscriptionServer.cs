using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    public abstract class SubscriptionServer<T>: IEnsSubscription 
        where T : class
    {
        public EventHandler OnSubscriberChanged;

        /// <summary>
        /// Keyed by event name and the value is the set of subscribers of the event.
        /// </summary>
        private readonly Dictionary<string, Dictionary<int, Subscription<T>>> subscribedMethods
            = new Dictionary<string, Dictionary<int, Subscription<T>>>();

        private readonly object locker = new object();

        protected SubscriptionServer()
        {
            var methods = Utils.GetOperations<T>();

            Action<string> insert = methodName => subscribedMethods.Add(methodName, new Dictionary<int, Subscription<T>>());

            Array.ForEach(methods, insert);
        }

        public void Subscribe(string subscriberName, string eventName)
        {
            lock (locker)
            {
                var subscriber = OperationContext.Current.GetCallbackChannel<T>();

                if (string.IsNullOrEmpty(eventName))
                {
                    var methods = Utils.GetOperations<T>();

                    Action<string> addTransient = methodName => AddSubscriber(subscriber, subscriberName, methodName);

                    Array.ForEach(methods, addTransient);
                }
                else
                {
                    AddSubscriber(subscriber, subscriberName, eventName);
                }
            }
        }

        public void Unsubscribe(string eventName)
        {
            lock (locker)
            {
                var subscriber = OperationContext.Current.GetCallbackChannel<T>();

                if (string.IsNullOrEmpty(eventName))
                {
                    var methods = Utils.GetOperations<T>();

                    Action<string> removeTransient = methodName => RemoveSubscriber(subscriber, methodName);

                    Array.ForEach(methods, removeTransient);
                }
                else
                {
                    RemoveSubscriber(subscriber, eventName);
                }
            }
        }

        private void AddSubscriber(T subscriber, string subscriberName, string eventOperation)
        {
            var key = subscriber.GetHashCode();

            lock (locker)
            {
                var dic = subscribedMethods[eventOperation];

                if (dic.ContainsKey(key)) return;

                dic.Add(subscriber.GetHashCode(), new Subscription<T>(subscriberName, subscriber));
            }

            OnSubscriberChanged?.Invoke(null, null);
        }

        private void RemoveSubscriber(T subscriber, string eventOperation)
        {
            lock (locker)
            {
                var dic = subscribedMethods[eventOperation];

                if (!dic.Remove(subscriber.GetHashCode())) return;
            }

            OnSubscriberChanged?.Invoke(null, null);
        }

        internal void RemoveSubscriber(T subscriber)
        {
            lock (locker)
            {
                foreach (var dic in subscribedMethods.Values.Where(dic => dic.ContainsKey(subscriber.GetHashCode())))
                {
                    dic.Remove(subscriber.GetHashCode());
                }
            }
        }

        internal T[] GetSubscribers(string eventName)
        {
            lock (locker)
            {
                if (!subscribedMethods.ContainsKey(eventName)) return new T[] { };

                var dic = subscribedMethods[eventName];

                return dic.Select(v => v.Value.Subscriber).ToArray();
            }
        }
    }
}

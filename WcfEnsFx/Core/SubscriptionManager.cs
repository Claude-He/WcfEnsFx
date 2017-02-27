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
    public abstract class SubscriptionManager<T> where T : class
    {
        public EventHandler OnSubscriberChanged;

        /// <summary>
        /// Keyed by event name and the value is the set of subscribers of the event.
        /// </summary>
        readonly Dictionary<string, Dictionary<int, Subscription<T>>> SubscribedMethods
            = new Dictionary<string, Dictionary<int, Subscription<T>>>();

        readonly object Locker = new object();               
        
        public SubscriptionManager()
        {
            var methods = Utils.GetOperations<T>();

            Action<string> insert = methodName => SubscribedMethods.Add(methodName, new Dictionary<int, Subscription<T>>());

            Array.ForEach(methods, insert);
        }

        public void Subscribe(string subscriberName, string eventName)
        {
            lock (Locker)
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
            lock (Locker)
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
        
        void AddSubscriber(T subscriber, string subscriberName, string eventOperation)
        {
            var key = subscriber.GetHashCode();

            lock (Locker)
            {
                var dic = SubscribedMethods[eventOperation];

                if (dic.ContainsKey(key)) return;

                dic.Add(subscriber.GetHashCode(), new Subscription<T>(subscriberName, subscriber));
            }

            if (OnSubscriberChanged != null) OnSubscriberChanged(null, null);
        }

        void RemoveSubscriber(T subscriber, string eventOperation)
        {
            lock (Locker)
            {
                var dic = SubscribedMethods[eventOperation];

                if (!dic.Remove(subscriber.GetHashCode())) return;
            }

            if (OnSubscriberChanged != null) OnSubscriberChanged(null, null);
        }

        internal void RemoveSubscriber(T subscriber)
        {
            lock (Locker)
            {
                foreach (var dic in SubscribedMethods.Values.Where(dic => dic.ContainsKey(subscriber.GetHashCode())))
                {
                    dic.Remove(subscriber.GetHashCode());
                }
            }
        }

        internal T[] GetSubscribers(string eventName)
        {
            lock (Locker)
            {
                if (!SubscribedMethods.ContainsKey(eventName)) return new T[] { };

                var dic = SubscribedMethods[eventName];

                return dic.Select(v => v.Value.Subscriber).ToArray();
            }
        }
    }
}

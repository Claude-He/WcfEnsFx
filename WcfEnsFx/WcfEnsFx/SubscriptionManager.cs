using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace WcfEnsFx
{
    public abstract class SubscriptionManager<T> where T : class
    {
        public static EventHandler OnSubscriberChanged;

        /// <summary>
        /// A dictionary where key is the name of event and the value is a 
        /// collection of registered subscribers to this event. 
        /// </summary>
        static readonly Dictionary<string, Dictionary<int, Subscription<T>>> SubscriptionStore 
            = new Dictionary<string, Dictionary<int, Subscription<T>>>();

        static readonly object Locker = new object();

        static SubscriptionManager()
        {
            var methods = GetOperations();

            Action<string> insert = methodName => SubscriptionStore.Add(methodName, new Dictionary<int, Subscription<T>>());

            Array.ForEach(methods, insert);

            PublishService<T>.OnSubscriberFailed += OnRaiseEventFailed;
        }

        public void Subscribe(string subscriberName, string eventOperation)
        {
            lock (Locker)
            {
                var subscriber = OperationContext.Current.GetCallbackChannel<T>();
                
                if (string.IsNullOrEmpty(eventOperation))
                {
                    var methods = GetOperations();

                    Action<string> addTransient = methodName => AddSubscriber(subscriber, subscriberName, methodName);

                    Array.ForEach(methods, addTransient);
                }
                else
                {
                    AddSubscriber(subscriber, subscriberName, eventOperation);
                }
            }
        }

        public void Unsubscribe(string eventOperation)
        {
            lock (Locker)
            {
                var subscriber = OperationContext.Current.GetCallbackChannel<T>();

                if (string.IsNullOrEmpty(eventOperation))
                {
                    var methods = GetOperations();

                    Action<string> removeTransient = methodName => RemoveSubscriber(subscriber, methodName);

                    Array.ForEach(methods, removeTransient);
                }
                else
                {
                    RemoveSubscriber(subscriber, eventOperation);
                }
            }
        }

        public bool IsSubscribed(string eventOperation)
        {
            var subscriber = OperationContext.Current.GetCallbackChannel<T>();

            if (!string.IsNullOrEmpty(eventOperation)) return IsSubscribed(subscriber, eventOperation);
           
            var methods = GetOperations();
            var isSubscribed = methods.All(method => IsSubscribed(subscriber, method));
            return isSubscribed;
        }
        
        public bool IsConnected()
        {
            return true;
        }

        internal static T[] GetTransientList(string eventOperation)
        {
            lock (Locker)
            {
                Debug.Assert(SubscriptionStore.ContainsKey(eventOperation));
                if (!SubscriptionStore.ContainsKey(eventOperation)) return new T[] { };

                var dic = SubscriptionStore[eventOperation];

                return dic.Select(v => v.Value.Subscriber).ToArray();
            }
        }

        /// <summary>
        /// Return a list of Subscriptions that subscribed to specified event.
        /// A Subscription is a wrapper of type T that has a friendly name.
        /// </summary>
        /// <param name="eventOperation">Specified event name.</param>
        /// <returns>List of Subscriptions that subscribed to the specified event</returns>
        internal static Subscription<T>[] GetSubscriptionList(string eventOperation)
        {
            lock (Locker)
            {
                Debug.Assert(SubscriptionStore.ContainsKey(eventOperation));
                if (!SubscriptionStore.ContainsKey(eventOperation)) return new Subscription<T>[] { };

                var dic = SubscriptionStore[eventOperation];
                return dic.Select(v => v.Value).ToArray();
            }
        }

        private static bool IsSubscribed(T subscriber, string eventOperation)
        {
            return SubscriptionStore.ContainsKey(eventOperation)
                && SubscriptionStore[eventOperation].ContainsKey(subscriber.GetHashCode());
        }

        static string[] GetOperations()
        {
            var type = typeof(T);

            const BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;

            var methods = new List<MethodInfo>(type.GetMethods(flags));

            foreach (Type t in type.GetInterfaces())
            {
                foreach (MethodInfo m in t.GetMethods(flags))
                {
                    methods.Add(m);
                }
            }

            var opearions = new List<string>(methods.Count);

            Action<MethodInfo> add = method =>
            {
                Debug.Assert(!opearions.Contains(method.Name));
                opearions.Add(method.Name);
            };

            Array.ForEach(methods.ToArray(), add);

            return opearions.ToArray();
        }

        static void AddSubscriber(T subscriber, string subscriberName, string eventOperation)
        {
            var key = subscriber.GetHashCode();

            lock (Locker)
            {
                var dic = SubscriptionStore[eventOperation];

                if (dic.ContainsKey(key)) return;

                dic.Add(subscriber.GetHashCode(), new Subscription<T>(subscriberName, subscriber));
            }

            if (OnSubscriberChanged != null) OnSubscriberChanged(null, null);
        }

        static void RemoveSubscriber(T subscriber, string eventOperation)
        {
            lock (Locker)
            {
                var dic = SubscriptionStore[eventOperation];

                if (!dic.Remove(subscriber.GetHashCode())) return;
            }

            if (OnSubscriberChanged != null) OnSubscriberChanged(null, null);
        }

        static internal void OnRaiseEventFailed(T subscriber)
        {
            Debug.WriteLine(subscriber + " Failed.");

            lock (Locker)
            {
                foreach (var dic in SubscriptionStore.Values.Where(dic => dic.ContainsKey(subscriber.GetHashCode())))
                {
                    dic.Remove(subscriber.GetHashCode());
                }
            }
        }
    }
}

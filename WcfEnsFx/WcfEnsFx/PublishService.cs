using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace WcfEnsFx
{
    public abstract class PublishService<T> where T : class
    {
        internal static Action<T> OnSubscriberFailed;
        
        /// <summary>
        /// Raise event to every subscribers of specified event.
        /// </summary>
        /// <param name="eventOperation">Name of event to be broadcasted.</param>
        /// <param name="args">args</param>
        public static void BroadcastLocalEvent(string eventOperation, params object[] args)
        {
            RaiseEvent(eventOperation, args);
        }

        /// <summary>
        /// Raise event to a specific subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber specified.</param>
        /// <param name="eventOperation">Name of event to be raised.</param>
        /// <param name="args">args</param>
        internal static void RaiseLocalEvent(T subscriber, string eventOperation, params object[] args)
        {
            Invoke(subscriber, eventOperation, args);
        }

        /// <summary>
        /// Raise event to a specific subscriber.
        /// </summary>
        /// <param name="returnValue"></param>
        /// <param name="subscriber">The subscriber specified.</param>
        /// <param name="eventOperation">Name of event to be raised.</param>
        /// <param name="args">args</param>
        internal static void RaiseLocalEvent(ref object returnValue, T subscriber, string eventOperation, params object[] args)
        {
            Invoke(ref returnValue, subscriber, eventOperation, args);
        }

        protected static Subscription<T>[] GetEventSubscriptions(string eventOperation)
        {
            return SubscriptionManager<T>.GetSubscriptionList(eventOperation);
        }

        protected static void TransitRemoteEvent(params object[] args)
        {
            var action = OperationContext.Current.IncomingMessageHeaders.Action;
            var slashes = action.Split('/');
            var methodName = slashes.Last(); //[slashes.Length - 1]

            RaiseEvent(methodName, args);
        }

        static void RaiseEvent(string methodName, object[] args)
        {
            PublishTransient(methodName, args);
        }

        static void PublishTransient(string methodName, object[] args)
        {
            var subscribers = SubscriptionManager<T>.GetTransientList(methodName);

            Publish(subscribers, methodName, args);
        }

        static void Publish(T[] subscribers, string methodName, object[] args)
        {
            WaitCallback fire = subscriber => Invoke(subscriber as T, methodName, args);
            
            Action<T> queueUp = subscriber => ThreadPool.QueueUserWorkItem(fire, subscriber);

            Array.ForEach(subscribers, queueUp);
        }

        static void Invoke(T subscriber, string methodName, object[] args)
        {
            Debug.Assert(subscriber != null);

            var type = typeof(T);

            var methodInfo = Util.GetMethod(typeof(T), methodName, args);

            try
            {
                methodInfo.Invoke(subscriber, args);
            }
            catch(Exception e)
            {
                if (OnSubscriberFailed != null)
                    OnSubscriberFailed(subscriber);
            }
        }

        static void Invoke(ref object o, T subscriber, string methodName, object[] args)
        {
            Debug.Assert(subscriber != null);

            var type = typeof(T);

            var methodInfo = type.GetMethod(methodName);

            try
            {
                o = methodInfo.Invoke(subscriber, args);
            }
            catch
            {
                if (OnSubscriberFailed != null)
                    OnSubscriberFailed(subscriber);
            }
        }

       
    }
}

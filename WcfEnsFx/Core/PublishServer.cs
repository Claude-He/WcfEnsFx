using System;
using System.Diagnostics;
using System.Threading;

namespace WcfEnsFx.Core
{
    public abstract class PublishServer<T> where T : class
    {
        ISubscriberCollection<T> SubscriptionServer { get; set; }

        /// <summary>
        /// Raise event to every subscribers of specified event.
        /// </summary>
        /// <param name="eventOperation">Name of event to be broadcasted.</param>
        /// <param name="args">args</param>
        public void BroadcastLocalEvent(string eventOperation, params object[] args)
        {
            RaiseEvent(eventOperation, args);
        }

        void RaiseEvent(string methodName, object[] args)
        {
            var subscribers = SubscriptionServer.GetSubscribers(methodName);

            Publish(subscribers, methodName, args);
        }              

        void Publish(T[] subscribers, string methodName, object[] args)
        {
            WaitCallback fire = subscriber => Invoke(subscriber as T, methodName, args);

            Action<T> queueUp = subscriber => ThreadPool.QueueUserWorkItem(fire, subscriber);

            Array.ForEach(subscribers, queueUp);
        }

        void Invoke(T subscriber, string methodName, object[] args)
        {
            Debug.Assert(subscriber != null);

            var type = typeof(T);

            var methodInfo = Utils.GetMethod(type, methodName, args);

            methodInfo.Invoke(subscriber, args);
        }



    }
}
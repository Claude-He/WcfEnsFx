using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace WcfEnsFx.Core
{
    public abstract class EventRelayService<T> where T: class
    {
        internal ISubscriberCollection<T> SubscriptionServer { get; set; }

        protected virtual void RelayEvent(params object[] args)
        {
            var frame = new StackFrame(1);
            var method = frame.GetMethod();

            var methodInfo = Utils.GetMethod(typeof(T), method.Name, args);

            BroadcastEvent(methodInfo, args);
        }

        private void BroadcastEvent(MethodInfo eventMethod, params object[] args)
        {
            var subscribers = SubscriptionServer.GetSubscribers(eventMethod.Name);

            RaiseEvent(subscribers, eventMethod, args);
        }

        private void RaiseEvent(T[] subscribers, MethodInfo eventMethod, object[] args)
        {
            WaitCallback callback = subscriber => Invoke(subscriber as T, eventMethod, args);

            Action<T> queueUp = subscriber => ThreadPool.QueueUserWorkItem(callback, subscriber);

            Array.ForEach(subscribers, queueUp);
        }

        private void Invoke(T subscriber, MethodInfo eventMethod, object[] args) 
        {
            try
            {
                eventMethod.Invoke(subscriber, args);
            }
            catch
            {
                SubscriptionServer.RemoveSubscriber(subscriber);
            }
        }
    }
}

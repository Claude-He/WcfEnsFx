using System;

namespace WcfEnsFx
{
    abstract class SubscriptionState<TS, T> : StateBase, ISubscription
        where TS : class
        where T : class
    {
        protected SubscriptionClientHelper<TS, T> ClientHelper;
        
        public abstract SubscriberState State { get; }
    
        protected SubscriptionState(SubscriptionClientHelper<TS, T> clientHelper)
        {
            if (clientHelper == null) throw new ArgumentNullException();

            ClientHelper = clientHelper;
        }

        #region ISubscriptionService

        public virtual void Subscribe(string subscriberName, string eventOperation)
        {
            ShowError();
        }

        public virtual bool IsSubscribed(string eventOperation)
        {
            ShowError();
            return false;
        }

        public virtual void Unsubscribe(string eventOperation)
        {
            ShowError();
        }

        public virtual bool IsConnected()
        {
            ShowError();
            return false;
        }

        #endregion
        
        #region ISubscription

        public virtual void Connect()
        {
            ShowError();
        }

        public virtual void Disconnect()
        {
            ShowError();
        }

        public virtual bool Invoke(string methodName, params object[] args)
        {
            ShowError();
            return false;
        }

        public virtual bool Invoke(ref object returnValue, string methodName, params object[] args)
        {
            ShowError();
            return false;
        }

        #endregion
    }
}

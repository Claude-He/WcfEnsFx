using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    class SubscribedState<TS, T> : CommunicatableState<TS, T>
        where TS : class
        where T : class
    {
        internal SubscribedState(SubscriptionClientHelper<TS, T> clientHelper)
            : base(clientHelper)
        { }

        public override SubscriberState State
        {
            get { return SubscriberState.Subscribed; }
        }

        public override void Unsubscribe(string eventOperation)
        {
            try
            {
                ClientHelper.ProxyWrapper.Unsubscribe(eventOperation);

                ClientHelper.CurrentState = ClientHelper.ConnectedState;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ClientHelper.CurrentState = ClientHelper.FaultedState;
            }
        }
    }
}

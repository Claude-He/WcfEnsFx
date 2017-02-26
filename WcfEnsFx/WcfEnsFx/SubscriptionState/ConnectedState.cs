using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    class ConnectedState<TS, T> : CommunicatableState<TS, T>
        where TS : class
        where T : class
    {
        internal ConnectedState(SubscriptionClientHelper<TS, T> clientHelper)
            : base(clientHelper)
        { }

        public override SubscriberState State
        {
            get { return SubscriberState.Connected; }
        }

        public override void Disconnect()
        {
            try
            {
                ClientHelper.ProxyWrapper.Disconnect();
                ClientHelper.CurrentState = ClientHelper.UnconnectedState;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ClientHelper.CurrentState = ClientHelper.FaultedState;
            }
        }

        public override void Subscribe(string subscriberName, string eventOperation)
        {
            try
            {
                ClientHelper.ProxyWrapper.Subscribe(subscriberName, eventOperation);
                ClientHelper.CurrentState = ClientHelper.SubscribedState;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ClientHelper.CurrentState = ClientHelper.FaultedState;
            }
        }
    }
}

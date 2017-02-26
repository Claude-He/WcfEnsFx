using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    class UnconnectedState<TS, T> : SubscriptionState<TS, T>
        where TS : class
        where T : class
    {
        internal UnconnectedState(SubscriptionClientHelper<TS, T> clientHelper)
            : base(clientHelper)
        { }

        public override SubscriberState State
        {
            get { return SubscriberState.Disconnected; }
        }

        public override void Connect()
        {
            try
            {
                ClientHelper.ProxyWrapper.Connect();

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

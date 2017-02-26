using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    class FaultedState<TS, T> : SubscriptionState<TS, T>
        where TS : class
        where T : class
    {
        internal FaultedState(SubscriptionClientHelper<TS, T> clientHelper)
            : base(clientHelper)
        { }

        public override SubscriberState State
        {
            get { return SubscriberState.Faulted; }
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

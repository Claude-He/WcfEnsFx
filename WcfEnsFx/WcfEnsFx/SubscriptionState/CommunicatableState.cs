using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    abstract class CommunicatableState<TS, T> : SubscriptionState<TS, T>
        where TS : class
        where T : class
    {
        internal CommunicatableState(SubscriptionClientHelper<TS, T> clientHelper)
            : base(clientHelper)
        { }

        public override bool IsSubscribed(string eventOperation)
        {
            return ClientHelper.ProxyWrapper.IsSubscribed(eventOperation);
        }

        public override bool IsConnected()
        {
            return ClientHelper.ProxyWrapper.IsConnected();
        }

        public override bool Invoke(string methodName, params object[] args)
        {
            try
            {
                return ClientHelper.ProxyWrapper.Invoke(methodName, args);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ClientHelper.CurrentState = ClientHelper.FaultedState;

                return false;
            }
        }

        public override bool Invoke(ref object returnValue, string methodName, params object[] args)
        {
            try
            {
                return ClientHelper.ProxyWrapper.Invoke(ref returnValue, methodName, args);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ClientHelper.CurrentState = ClientHelper.FaultedState;

                return false;
            }
        }
    }
}

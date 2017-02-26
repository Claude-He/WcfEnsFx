namespace WcfEnsFx
{
    interface ISubscription : ISubscriptionService
    {
        void Connect();

        void Disconnect();
        
        bool Invoke(string methodName, params object[] args);

        bool Invoke(ref object returnValue, string methodName, params object[] args);
    }
}

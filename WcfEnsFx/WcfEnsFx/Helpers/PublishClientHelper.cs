using System;
using System.Diagnostics;

namespace WcfEnsFx
{
    ///// <summary>
    ///// Used by remote publisher clients to raise events.
    ///// </summary>
    ///// <typeparam name="T">Events contract for callback.</typeparam>
    public class PublishClientHelper<T> : System.ServiceModel.ClientBase<T> where T : class
    {
        public PublishClientHelper()
        {}

        public PublishClientHelper(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {}

        public PublishClientHelper(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {}

        public PublishClientHelper(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {}

        public PublishClientHelper(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {}
         
        public void TryEvent(string methodName, params object[] args)
        {
            if (methodName == null) throw new ArgumentNullException("methodName");

            TryEvent(Channel, methodName, args);
        }

        public void TryEvent(ref object returnValue, string subscriberName, string methodName, params object[] args)
        {
            if (methodName == null) throw new ArgumentNullException("methodName");

            returnValue = TryEvent(Channel, subscriberName, methodName, args);
        }

        public void TryEvent(ref object returnValue, string methodName, params object[] args)
        {
            if (methodName == null) throw new ArgumentNullException("methodName");

            returnValue = TryEvent(Channel, methodName, args);
        }

        private static object TryEvent(T t, string methodName, object[] args)
        {
            var methodInfo = Util.GetMethod(typeof(T), methodName, args);

            if (Equals(methodInfo, null))
                throw new InvalidOperationException(
                    string.Format("Cannot find method=[{0}] in type[{1}].", methodName, typeof(T)));

            return methodInfo.Invoke(t, args);
        }

        private static object TryEvent(T t, string subscriberName, string methodName, object[] args)
        {
            var methodInfo = Util.GetMethod(typeof(T), methodName, args);

            if (Equals(methodInfo, null))
                throw new InvalidOperationException(
                    string.Format("Cannot find method=[{0}] in type[{1}].", methodName, typeof(T)));

            return methodInfo.Invoke(t, args);
        }
    }
}

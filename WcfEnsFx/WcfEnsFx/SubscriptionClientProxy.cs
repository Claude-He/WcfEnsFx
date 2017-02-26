using System;
using System.Reflection;

namespace WcfEnsFx
{
    class SubscriptionClientProxy<T> : System.ServiceModel.DuplexClientBase<T> where T : class
    {
        internal SubscriptionClientProxy(System.ServiceModel.InstanceContext callbackInstance) :
            base(callbackInstance)
        { }

        //protected SubscriptionClientProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
        //    base(callbackInstance, endpointConfigurationName)
        //{ }

        //protected SubscriptionClientProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
        //    base(callbackInstance, endpointConfigurationName, remoteAddress)
        //{ }

        //protected SubscriptionClientProxy(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        //    base(callbackInstance, endpointConfigurationName, remoteAddress)
        //{ }

        //protected SubscriptionClientProxy(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        //    base(callbackInstance, binding, remoteAddress)
        //{ }

        public void Invoke(string methodName, params object[] args)
        {
            if (methodName == null) throw new ArgumentNullException("methodName");

            Invoke(Channel, methodName, args);
        }

        public void Invoke(ref object returnValue, string methodName, params object[] args)
        {
            if (methodName == null) throw new ArgumentNullException("methodName");

            returnValue = Invoke(Channel, methodName, args);
        }

        private static object Invoke(T t, string methodName, object[] args)
        {
            var methodInfo = Util.GetMethod(typeof(T), methodName, args);

            if (Equals(methodInfo, null))
                throw new InvalidOperationException(
                    string.Format("Cannot find method=[{0}] in type[{1}].", methodName, typeof(T)));

            return methodInfo.Invoke(t, args);
        }
    }
   
}

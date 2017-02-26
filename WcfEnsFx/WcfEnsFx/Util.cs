using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Reflection;

namespace WcfEnsFx
{
    public class Util
    {
        [Conditional("DEBUG")]
        public static void DisplayHostInfo(ServiceHostBase host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");
            if (host != null)
            {
                Console.WriteLine("ServiceType: {0}", host.Description.ServiceType);
                Console.WriteLine();
                Console.WriteLine("State: {0}", host.State);
                Console.WriteLine();
                foreach (var se in host.Description.Endpoints)
                {
                    Console.WriteLine("Address: {0}", se.Address);
                    Console.WriteLine("Binding: {0}", se.Binding.Name);
                    Console.WriteLine("Contract: {0}", se.Contract.Name);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Null host.");
            }

            Console.WriteLine("**********************");
        }

        public static MethodInfo GetMethod(Type type, string methodName, object[] args)
        {
            var methodInfo = type.GetMethod(methodName, GetTypeArray(args));

            if (methodInfo != null) return methodInfo;

            foreach (var interf in type.GetInterfaces())
            {
                methodInfo = interf.GetMethod(methodName);

                if (methodInfo != null) return methodInfo;
            }

            return null;
        }

        private static Type[] GetTypeArray(object[] args)
        {
            var paramNum = args == null ? 0 : args.Length;

            var types = new Type[paramNum];

            for (var i = 0; i < paramNum; i++)
            {
                if (args != null)
                {
                    types[i] = args[i].GetType();
                }
                else
                {
                    types[i] = null;
                    //throw new ArgumentException("One of the args is null.");
                }
            }

            return types;
        }

      
    }
}

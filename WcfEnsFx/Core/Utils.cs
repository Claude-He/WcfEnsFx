using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace WcfEnsFx.Core
{
    internal class Utils
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

        public static string[] GetOperations<T>()
        {          
            const BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;

            var type = typeof(T);
            var methods = new List<MethodInfo>(type.GetMethods(flags));

            foreach (var t in type.GetInterfaces())
            {
                methods.AddRange(t.GetMethods(flags));
            }

            var operations = new HashSet<string>();

            foreach (var method in methods)
            {
                if (!operations.Contains(method.Name))
                {
                    operations.Add(method.Name);
                }
            }

            return operations.ToArray();
        }

        public static MethodInfo GetMethod(Type type, string methodName, object[] args)
        {
            var methodInfo = type.GetMethod(methodName, GetArgsTypes(args));

            if (methodInfo != null) return methodInfo;

            foreach (var interf in type.GetInterfaces())
            {
                methodInfo = interf.GetMethod(methodName);

                if (methodInfo != null) return methodInfo;
            }

            return null;
        }

        private static Type[] GetArgsTypes(IReadOnlyList<object> args)
        {
            var paramNum = args?.Count ?? 0;

            var types = new Type[paramNum];

            for (var i = 0; i < paramNum; i++)
            {
                types[i] = args?[i] != null ? args[i].GetType() : null;
            }

            return types;
        }
    }
}

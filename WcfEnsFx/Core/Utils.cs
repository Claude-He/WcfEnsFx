using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfEnsFx.Core
{
    class Utils
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
            var methods = new List<MethodInfo>(typeof(T).GetMethods(flags));

            foreach (Type t in type.GetInterfaces())
            {
                foreach (MethodInfo m in t.GetMethods(flags))
                {
                    methods.Add(m);
                }
            }

            var operations = new List<string>(methods.Count);

            Action<MethodInfo> add = method =>
            {
                Debug.Assert(!operations.Contains(method.Name));
                operations.Add(method.Name);
            };

            Array.ForEach(methods.ToArray(), add);

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

        static Type[] GetArgsTypes(object[] args)
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
                }
            }

            return types;
        }
    }
}

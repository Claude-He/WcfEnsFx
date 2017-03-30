using System;
using System.Configuration;
using System.ServiceModel;

namespace WcfEnsFx.Core
{
    internal class ServiceWrapper<TC, TI>: ServiceHost
        where TC : class, TI
    {
        internal event ServiceStateChangedEventHandler ServiceStateChanged;

        protected ServiceHost ServiceHost { get; set; }

        //internal virtual void Open()
        //{
        //    ServiceHost = new ServiceHost(typeof(TC));

        //    ServiceHost.Opened += OnStateChanged;
        //    ServiceHost.Opening += OnStateChanged;
        //    ServiceHost.Closing += OnStateChanged;
        //    ServiceHost.Closed += OnStateChanged;
        //    ServiceHost.Faulted += OnStateChanged;

        //    var openNetTcp = true;//Convert.ToBoolean(ConfigurationManager.AppSettings["OpenNetTcp"]);
        //    if (openNetTcp)
        //    {
        //        var tcpPublishBinding = new NetTcpBinding(SecurityMode.None);
        //        var addressPub = "net.tcp://localhost:7002/SubscriptionService";//ConfigurationManager.AppSettings["NetTcpPublishmentServiceAddress"];
        //        ServiceHost.AddServiceEndpoint(typeof(TI), tcpPublishBinding, addressPub);
        //    }

        //    ServiceHost.Open();

        //    Utils.DisplayHostInfo(ServiceHost);
        //}

        //internal void Close()
        //{
        //    ServiceHost.Close();
        //}

        protected void OnStateChanged(object sender, EventArgs e)
        {
            ServiceStateChanged?.Invoke(ServiceHost.State);
        }
    }

  
}

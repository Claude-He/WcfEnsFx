using MyContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfEnsFx.Core;

namespace MyEnsServer
{
    public partial class FEnsServer : Form
    {
        private EnsService<MyService, IMyService, MyEventRelayService, IMyEvent> Service { get; set; }
        
        public FEnsServer()
        {
            InitializeComponent();
        }

        private void FEnsServer_Load(object sender, EventArgs e)
        {
            Service = new EnsService<MyService, IMyService, MyEventRelayService, IMyEvent>();

            Service.PublishServiceStateChanged += newState =>
            {
                lbl_pubState.Text = $@"Publish Service State: {newState}";
            };

            Service.SubscriptionServiceStateChanged += newState =>
            {
                lbl_subState.Text = $@"Subscription Service State: {newState}";
            };

            UpdateUi();
        }

        private void BtnClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn == btnRaiseEvent) RaiseLocalEvent();
            else if (btn == btnOpenSubscriberService) OpenSubscriberService();
            else if (btn == btnCloseSubscriberService) CloseSubscriberService();
            else if (btn == btnOpenPublisherService) OpenPublisherService();
            else if (btn == btnClosePublisherService) ClosePublisherService();

            UpdateUi();
        }

        private void UpdateUi()
        {
            btnOpenPublisherService.Enabled = Service.PublishServerState == CommunicationState.Created ||
                                              Service.PublishServerState == CommunicationState.Closed;
            btnClosePublisherService.Enabled = !btnOpenPublisherService.Enabled;

            btnOpenSubscriberService.Enabled = Service.SubscriptionServerState == CommunicationState.Created ||
                                               Service.SubscriptionServerState == CommunicationState.Closed;
            btnCloseSubscriberService.Enabled = !btnOpenSubscriberService.Enabled;

            btnRaiseEvent.Enabled = Service.SubscriptionServerState == CommunicationState.Opened;
        }

        private void ClosePublisherService()
        {
            Service.ClosePublishService();
        }

        private void OpenPublisherService()
        {
            Service.OpenPublishService();
        }

        private void CloseSubscriberService()
        {
            Service.CloseSubscriptionService();
        }

        private void OpenSubscriberService()
        {
            Service.OpenSubscriptionService();
        }

        private void RaiseLocalEvent()
        {
            //throw new NotImplementedException();
        }

        
    }
}

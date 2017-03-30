using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyContract;
using MyTcpSubscriber.ServiceReference;

namespace MyTcpSubscriber
{
    public partial class FSubscriber : Form, IMyEvent, IMyServiceCallback
    {
        private MyServiceClient Client { get; }

        public FSubscriber()
        {
            InitializeComponent();

            Client = new MyServiceClient(new InstanceContext(this));
        }

        private void BtnClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn == btnAskService) AskService();
            else if (btn == btnSubscribe) Subscribe();
            else if (btn == btnUnsubscribe) Unsubscribe();
            else if (btn == btnClear) dgvEvents.Rows.Clear();
        }

        private void Unsubscribe()
        {
            Client.Unsubscribe(string.Empty);

            btnSubscribe.Enabled = true;
            btnUnsubscribe.Enabled = !btnSubscribe.Enabled;
        }

        private void Subscribe()
        {
            Client.Subscribe("TcpSubscriber", string.Empty);

            btnSubscribe.Enabled = false;
            btnUnsubscribe.Enabled = !btnSubscribe.Enabled;
        }

        private void AskService()
        {
            var serverTime = Client.GetTime();

            txtServerTime.Text = $@"Server Time: '{serverTime}'";
        }

        public void DemoEvent(string eventMessage)
        {
            if (dgvEvents.InvokeRequired)
            {
                Invoke(new Action<string>(DemoEvent), eventMessage);
            }
            else
            {
                dgvEvents.Rows.Add(DateTime.Now, eventMessage);
            }
        }

        public void DemoEvent(string eventMessage, int intParam)
        {
            if (dgvEvents.InvokeRequired)
            {
                Invoke(new Action<string>(DemoEvent), eventMessage, intParam);
            }
            else
            {
                dgvEvents.Rows.Add(DateTime.Now, $@"{eventMessage} + intParam");
            }
        }
    }
}

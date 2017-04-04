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
using MyForms.SubscriptionServiceRef;

namespace MyForms
{
    public partial class FSubscriber : Form, IMyServiceCallback
    {
        private MyServiceClient Client { get; }

        public FSubscriber(string bindingType)
        {
            InitializeComponent();

            Text = bindingType;

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

        public void DemoEvent(string strArg)
        {
            if (dgvEvents.InvokeRequired)
            {
                Invoke(new Action<string>(DemoEvent), strArg);
            }
            else
            {
                dgvEvents.Rows.Add(DateTime.Now, strArg);
            }
        }

        public void DemoEventWithInt(string strArg, int intArg)
        {
            if (dgvEvents.InvokeRequired)
            {
                Invoke(new Action<string>(DemoEvent), strArg, intArg);
            }
            else
            {
                dgvEvents.Rows.Add(DateTime.Now, $@"{strArg} + {intArg}");
            }
        }


    }
}

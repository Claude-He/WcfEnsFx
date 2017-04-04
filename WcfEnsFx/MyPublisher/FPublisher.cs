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
using MyPublisher.ServiceReference;

namespace MyPublisher
{
    public partial class FPublisher : Form
    {
        public FPublisher()
        {
            InitializeComponent();
        }

        private void btnRaiseEvent_Click(object sender, EventArgs e)
        {
            new MyEventClient().DemoEvent(txtEventMessage.Text);
        }

        private void btnEventWithNumber_Click(object sender, EventArgs e)
        {
            var number = Convert.ToInt32(txtEventNumber.Text);
            new MyEventClient().DemoEventWithInt(txtEventMessage.Text, number);
        }
    }
}

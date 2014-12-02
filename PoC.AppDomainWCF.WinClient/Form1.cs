using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace PoC.AppDomainWCF.WinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            ChannelFactory<ICrossAppDomainSvc> channelFactory = new ChannelFactory<ICrossAppDomainSvc>(binding);

            EndpointAddress endpointAddress = new EndpointAddress("net.pipe://localhost/CrossAppDomainSvc/");

            ICrossAppDomainSvc service = channelFactory.CreateChannel(endpointAddress);

            textBox1.Text = service.GetRandomText();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows.Forms;

namespace PoC.AppDomainWCF.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread thread = new Thread(new ThreadStart(StartService));
            thread.Start();

            Application.Run(new Form1());
        }

        static void StartService()
        {
            using (ServiceHost host = new ServiceHost(typeof(CrossAppDomainSvc), new Uri[] {
                new Uri("http://localhost:12000/AppDomainWCF/"),
                new Uri("net.pipe://localhost/")
            }))
            {
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                host.AddServiceEndpoint(typeof(ICrossAppDomainSvc), binding, "CrossAppDomainSvc");

                // Add a MEX endpoint
                //ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
                //metadataBehavior.HttpGetEnabled = true;
                //metadataBehavior.HttpGetUrl = new Uri("http://localhost:12001/AppDomainWCF");
                //host.Description.Behaviors.Add(metadataBehavior);

                host.Open();

                while (true) { }
            }
        }
    }
}

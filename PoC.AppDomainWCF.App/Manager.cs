using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PoC.AppDomainWCF.App
{
    public class Manager
    {
        public static void ExecutarModulo(String projeto)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = System.Environment.CurrentDirectory;
            setup.DisallowBindingRedirects = false;
            setup.DisallowCodeDownload = true;

            if (AppDomain.CurrentDomain != null && AppDomain.CurrentDomain.ApplicationTrust != null)
            {
                setup.ApplicationTrust = AppDomain.CurrentDomain.ApplicationTrust;
            }

            var appDomain = AppDomain.CreateDomain(projeto, null, setup);

            //IControllerWinForms controller = appDomain.CreateInstanceAndUnwrap(projeto, projeto + ".Controller") as IControllerWinForms;
            IController controller = appDomain.CreateInstanceAndUnwrap(projeto, projeto + ".Controller") as IController;

            Thread threadMod = new Thread(new ParameterizedThreadStart(Executar));
            threadMod.IsBackground = true;
            threadMod.SetApartmentState(ApartmentState.STA);
            threadMod.Start(new ParametroThread() { Aplicacao = controller });
        }

        private static void Executar(Object data)
        {
            ((ParametroThread)data).Aplicacao.OpenMainForm();
        }
    }

    class ParametroThread
    {
        public IController Aplicacao { get; set; }

        public Manager Manager { get; set; }
    }
}

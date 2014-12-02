using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoC.AppDomainWCF.WinClient
{
    [Serializable]
    class Controller : IController
    {
        public void OpenMainForm()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}

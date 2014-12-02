using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoC.AppDomainWCF.App
{
    class CrossAppDomainSvc : ICrossAppDomainSvc
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public string GetRandomText()
        {            
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 15; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}

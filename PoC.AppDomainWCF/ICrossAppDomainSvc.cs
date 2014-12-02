using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PoC.AppDomainWCF
{
    [ServiceContract(Namespace = "http://PoC.AppDomainWCF")]
    public interface ICrossAppDomainSvc
    {
        [OperationContract]
        string GetRandomText();
    }
}

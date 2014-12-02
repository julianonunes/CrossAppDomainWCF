CrossAppDomainWCF
=================

This is just a proof-of-concept regarding cross AppDomain communication via WCF and NamedPipes.

The main project is PoC.AppDomainWCF.App which hosts the WCF service and contains the Manager class to create new AppDomains and load assemblies into it.

PoC.AppDomainWCF.WinClient and PoC.AppDomainWCF.WPFClient are just simple projects to test the cross AppDomain communication.

And lastly but not least :) PoC.AppDomainWCF holds the interfaces for the service and controller classes.


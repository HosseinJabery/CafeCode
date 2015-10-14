using System;
using System.Web.Mvc;
using System.Web.Routing;
using IocConfig;

namespace CompanyWebSite.Infrastructure
{
    public class CustomControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
           return Configuration.Inject().GetInstance(controllerType) as IController;
        }
    }
}
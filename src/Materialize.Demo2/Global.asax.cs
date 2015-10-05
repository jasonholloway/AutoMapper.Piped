using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Materialize.Demo2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            RouteTable.Routes.MapRoute(
                                "Info",
                                "",
                                new { Controller = "Info", Action = "Index" });

        }
    }
}

using Materialize.Demo2.SignalR;
using Materialize.Demo2.QueryInfo;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Materialize.Demo2.Reporting;

namespace Materialize.Demo2.Config
{
    public static class NinjectConfig
    {
        public static void Register(IAppBuilder app) 
        {
            var kernel = new StandardKernel();
        
            kernel.Bind<SnooperSource>()
                    .ToSelf()
                    .InSingletonScope();

            kernel.Bind<ReportRegistry>()
                    .ToSelf()
                    .InSingletonScope();

            app.Properties["kernel"] = kernel;

            app.UseNinjectMiddleware(() => kernel);
        }
        
    }
    
}
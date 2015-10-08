using Materialize.Demo2.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Demo2.Config
{
    public static class SignalRConfig
    {
        public static void Register(IAppBuilder app) 
        {
            var kernel = (IKernel)app.Properties["kernel"];

            GlobalHost.DependencyResolver = new NinjectResolverAdaptor(kernel);

            kernel.Bind<IConnectionManager>()
                    .ToMethod(_ => new ConnectionManager(GlobalHost.DependencyResolver));

            kernel.Bind<IHubContext<IQueryInfoHub>>()
                    .ToMethod(_ => GlobalHost.ConnectionManager.GetHubContext<IQueryInfoHub>("QueryInfoHub"));


            app.MapSignalR(new HubConfiguration() {
                EnableDetailedErrors = true
            });

        }


        class NinjectResolverAdaptor : DefaultDependencyResolver
        {
            IKernel _kernel;

            public NinjectResolverAdaptor(IKernel kernel) {
                _kernel = kernel;
            }

            public override object GetService(Type serviceType) {
                return _kernel.TryGet(serviceType) ?? base.GetService(serviceType);
            }

            public override IEnumerable<object> GetServices(Type serviceType) {
                return _kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
            }
        }

    }
}
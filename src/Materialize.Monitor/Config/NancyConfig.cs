using Nancy;
using Nancy.Bootstrappers.Ninject;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Materialize.Monitor.Config
{
    public static class NancyConfig
    {
        public static void Register(IAppBuilder app) 
        {
            var kernel = (IKernel)app.Properties["kernel"];

            app.UseNancy(x => {
                x.Bootstrapper = new NancyBootstrapperShim(kernel);
            });
        }


        class NancyBootstrapperShim : NinjectNancyBootstrapper
        {
            IKernel _kernel;

            public NancyBootstrapperShim(IKernel kernel) {
                _kernel = kernel;
            }

            protected override IKernel CreateRequestContainer(NancyContext context) {
                return new ChildKernel(_kernel);
            }
        }
    }
}
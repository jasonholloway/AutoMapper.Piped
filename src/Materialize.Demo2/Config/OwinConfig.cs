using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Nancy;
using Ninject;
using Nancy.Bootstrappers.Ninject;
using Ninject.Extensions.ChildKernel;

[assembly: OwinStartup(typeof(Materialize.Demo2.Config.OwinConfig))]

namespace Materialize.Demo2.Config
{
    public class OwinConfig
    {
        public void Configuration(IAppBuilder app) 
        {
            app.MapSignalR();
            
            var rootKernel = NinjectConfig.CreateRootKernel();

            app.UseNinjectMiddleware(() => new ChildKernel(rootKernel));
            
            app.UseNinjectWebApi(WebApiConfig.GetHttpConfiguration());
            
            app.UseNancy(x => {
                x.Bootstrapper = new NinjectNancyBootstrapperShim(new ChildKernel(rootKernel));
            });
        }
    }



    class NinjectNancyBootstrapperShim : NinjectNancyBootstrapper
    {
        IKernel _kernel;

        public NinjectNancyBootstrapperShim(IKernel kernel) {
            _kernel = kernel;
        }
        
        protected override IKernel CreateRequestContainer(NancyContext context) {
            return _kernel;
        }
    }


}
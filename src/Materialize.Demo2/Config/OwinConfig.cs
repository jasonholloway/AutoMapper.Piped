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
using Microsoft.AspNet.SignalR;
using Materialize.Demo2.QueryInfo;
using Materialize.Demo2.Hubs;
using Ninject.Activation;
using Ninject.Activation.Blocks;
using Ninject.Components;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;
using System.Reflection;

[assembly: OwinStartup(typeof(Materialize.Demo2.Config.OwinConfig))]

namespace Materialize.Demo2.Config
{
    public class OwinConfig
    {
        public void Configuration(IAppBuilder app) 
        {
            NinjectConfig.Register(app);
            SignalRConfig.Register(app);
            WebApiConfig.Register(app);
            NancyConfig.Register(app);
            
            var kernel = (IKernel)app.Properties["kernel"];
            
            var queryInfoSource = kernel.Get<QueryInfoSource>();
            var queryInfoHubContext = kernel.Get<IHubContext<IQueryInfoHub>>();

            queryInfoSource.QueryReceived.Subscribe(qi => {
                queryInfoHubContext.Clients.All.AnnounceNewQueryInfo(qi.QueryID);
            });
        }
    }
    

}
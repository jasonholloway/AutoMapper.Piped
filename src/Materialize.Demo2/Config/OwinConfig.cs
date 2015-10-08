using Materialize.Demo2.Hubs;
using Materialize.Demo2.QueryInfo;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Ninject;
using Owin;
using System;

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
using Materialize.Demo2.SignalR;
using Materialize.Demo2.QueryInfo;
using Materialize.Demo2.Reporting;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Ninject;
using Owin;
using System;
using System.Reactive.Linq;

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
            
            var snooperSource = kernel.Get<SnooperSource>();
            var reportRegistry = kernel.Get<ReportRegistry>();
            var reportHubContext = kernel.Get<IHubContext<IReportHubClient>>();
            
            snooperSource.ReturnedReports
                            .Subscribe(r => reportRegistry.Add(r));

            reportRegistry.AddedReports
                            .Subscribe(r => reportHubContext.Clients.All.AnnounceNewReport((int)r.ReportID));

        }
    }
    

}
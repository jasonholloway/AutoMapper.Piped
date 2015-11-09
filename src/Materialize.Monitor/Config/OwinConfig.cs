using Materialize.Monitor.SignalR;
using Materialize.Monitor.QueryInfo;
using Materialize.Monitor.Reporting;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Ninject;
using Owin;
using System;
using System.Reactive.Linq;

[assembly: OwinStartup(typeof(Materialize.Monitor.Config.OwinConfig))]

namespace Materialize.Monitor.Config
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
                            .Subscribe(r => reportHubContext.Clients.All.AnnounceNewReport(r.SessionGuid.ToString(), r.ReportID));

        }
    }
    

}
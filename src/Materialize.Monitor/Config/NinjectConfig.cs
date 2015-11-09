using Materialize.Monitor.QueryInfo;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Owin;
using Materialize.Monitor.Reporting;

namespace Materialize.Monitor.Config
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
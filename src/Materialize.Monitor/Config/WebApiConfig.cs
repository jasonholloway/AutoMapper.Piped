//using Materialize.Tests.Model;
using Newtonsoft.Json;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Materialize.Monitor
{
    public static class WebApiConfig
    {

        public static void Register(IAppBuilder app) {
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
            
            //var builder = new ODataConventionModelBuilder();
            //builder.EntitySet<DogAndOwnerModel>("Dogs"); //.EntityType.HasKey(o => o.Name);

            //builder.EntitySet<PersonWithPetsModel>("People");

            config.MapHttpAttributeRoutes();

            //config.MapODataServiceRoute(
            //            "OData",
            //            "odata",
            //            builder.GetEdmModel());

            app.UseNinjectWebApi(config);
        }

    }
}

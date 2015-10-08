using Materialize.Tests.Model;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Materialize.Demo2
{
    public static class WebApiConfig
    {

        public static void Register(IAppBuilder app) 
        {
            var config = new HttpConfiguration();
            
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<DogAndOwnerModel>("Dogs"); //.EntityType.HasKey(o => o.Name);

            //builder.EntitySet<PersonWithPetsModel>("People");

            config.MapODataServiceRoute(
                        "OData",
                        "odata",
                        builder.GetEdmModel());
                        
            app.UseNinjectWebApi(config);
        }

    }
}

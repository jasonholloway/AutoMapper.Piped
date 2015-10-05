using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Materialize.Demo2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<DogAndOwnerModel>("Dogs"); //.EntityType.HasKey(o => o.Name);

            //builder.EntitySet<PersonWithPetsModel>("People");

            config.MapODataServiceRoute(
                        "OData",
                        "odata",
                        builder.GetEdmModel());            
        }
    }
}

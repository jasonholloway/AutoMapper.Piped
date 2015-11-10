//using Materialize.Tests.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Materialize.Monitor
{
    public static class WebApiConfig
    {

        public static void Register(IAppBuilder app) {
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new NonPublicPropertiesResolver();
            config.Formatters.JsonFormatter.SerializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
                
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



        class NonPublicPropertiesResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
                var prop = base.CreateProperty(member, memberSerialization);
                var pi = member as PropertyInfo;
                if(pi != null) {
                    prop.Readable = (pi.GetMethod != null);
                    prop.Writable = (pi.SetMethod != null);
                }
                return prop;
            }
        }


    }
}

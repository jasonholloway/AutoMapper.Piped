using AutoMapper;
using Materialize.SourceRegimes;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;

namespace Materialize.Demo2.Controllers
{
    public class DogsController : ODataController
    {

        static DogsController() {
            Mapper.CreateMap<Dog, DogAndOwnerModel>();
            Mapper.CreateMap<Person, PersonModel>();

            MaterializeServices.Init(x => {
                x.EmplaceSourceRegimeProvider(new EF6RegimeProvider());
            });
        }


        Context _ctx = new Context();
        
        [EnableQuery]
        public IQueryable<DogAndOwnerModel> Get() {
            return _ctx.Dogs.MapAs<DogAndOwnerModel>();
        }


        protected override void Dispose(bool disposing) {
            _ctx.Dispose();
            base.Dispose(disposing);    
        }

    }
}
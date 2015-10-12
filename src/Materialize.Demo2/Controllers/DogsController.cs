using AutoMapper;
using Materialize.Demo2.QueryInfo;
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
        SnooperSource _snooperSource;

        public DogsController(SnooperSource snooperSource) {
            _snooperSource = snooperSource;
        }


        [EnableQuery]
        public IQueryable<DogAndOwnerModel> Get() 
        {
            var snooper = _snooperSource.GetNewSnooper();

            return _ctx.Dogs.MapAs<DogAndOwnerModel>(snooper);
        }


        protected override void Dispose(bool disposing) {
            _ctx.Dispose();
            base.Dispose(disposing);    
        }

    }
}
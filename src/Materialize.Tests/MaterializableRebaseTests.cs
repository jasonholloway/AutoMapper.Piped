using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializableRebaseTests : TestClassBase
    {

        private IQueryable<Dog> Dogs { get; set; }

        public MaterializableRebaseTests() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>();
            });

            Dogs = Data.Dogs.AsQueryable();
        }
        
        
        [Fact]
        public void SimpleMappedProperties() 
        {
            int fetchedCount = 0;

            var snooper = new Snooper();
            snooper.Fetched += (en => fetchedCount = en.Count());

            var dogModels = Dogs.MapAs<DogModel>(snooper)
                                    .Where(m => m.Name.Length > 5)
                                    .ToArray();

            dogModels.Select(d => d.Name)
                .SequenceEqual(Dogs.Where(d => d.Name.Length > 5).Select(d => d.Name))
                .ShouldBeTrue();

            fetchedCount.ShouldEqual(dogModels.Count());
        }



        //un-rebasable predicates should either throw consistent exception
        //or cause all data to be brought forth first! - dependent on switch

        //before-and-after hooks should only apply after all filtering done.
        //...


        [Fact]
        public void NestedEnumerableMethods() {
            //within predicates, everything becomes enumerable
            //...

            throw new NotImplementedException();
        }

        

    }
}

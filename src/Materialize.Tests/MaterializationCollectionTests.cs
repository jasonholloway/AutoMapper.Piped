using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializationCollectionTests : TestClassBase
    {
        [Fact]
        public void MapsToCollections() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Person, PersonWithPetsModel>();
            });

            var people = Data.People.AsQueryable();

            var personModels = people.MaterializeAs<PersonWithPetsModel>()
                                .ToArray();

            personModels.SelectMany(p => p.Dogs.Select(d => d.Name))
                .SequenceEqual(people.SelectMany(p => p.Dogs.Select(d => d.Name)))
                .ShouldBeTrue();
        }


        [Fact]
        public void MapsToArrays() {
            throw new NotImplementedException();
        }

        [Fact]
        public void MapsToLists() {
            throw new NotImplementedException();
        }


        [Fact]
        public void MapsToEnumerables() {
            throw new NotImplementedException();
        }
        


        //...
    }
}

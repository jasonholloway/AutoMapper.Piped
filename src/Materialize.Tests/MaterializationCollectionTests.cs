using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using System;
using System.Collections;
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
        public void MapsToIEnumerable() {
            MapsToCollection<IEnumerable<DogModel>>();
        }

        [Fact]
        public void MapsToIEnumerableNonGen() {
            MapsToCollection<IEnumerable>();
        }
        
        [Fact]
        public void MapsToArray() {
            MapsToCollection<DogModel[]>();
        }

        [Fact]
        public void MapsToList() {
            MapsToCollection<List<DogModel>>();
        }
        
        [Fact]
        public void MapsToIList() {
            MapsToCollection<IList<DogModel>>();
        }

        [Fact]
        public void MapsToIListNonGen() {
            MapsToCollection<IList>();
        }
        
        [Fact]
        public void MapsToICollection() {
            MapsToCollection<ICollection<DogModel>>();
        }

        [Fact]
        public void MapsToICollectionNonGen() {
            MapsToCollection<ICollection>();
        }



        void MapsToCollection<TColl>()
            where TColl : IEnumerable
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Person, DogOwnerModel<TColl>>();
            });

            var people = Data.People.AsQueryable();

            var personModels = people.MaterializeAs<DogOwnerModel<TColl>>()
                                .ToArray();

            personModels.SelectMany(p => p.Dogs.Cast<DogModel>().Select(d => d.Name))
                .SequenceEqual(people.SelectMany(p => p.Dogs.Select(d => d.Name)))
                .ShouldBeTrue();
        }

        
        class DogOwnerModel<TColl>
            where TColl : IEnumerable
        {
            public string Name { get; set; }
            public TColl Dogs { get; set; }
        }
        
    }
}

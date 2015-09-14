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
        //All a question of making appropriate CollectionFactories available

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

        [Fact]
        public void MapsToISet() {
            MapsToCollection<ISet<DogModel>>();
        }

        [Fact]
        public void MapsToHashSet() {
            MapsToCollection<HashSet<DogModel>>();
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

            var ownerModels = people.MaterializeAs<DogOwnerModel<TColl>>()
                                .ToArray();

            ownerModels.SelectMany(p => p.Dogs.Cast<DogModel>().Select(d => d.Name))
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

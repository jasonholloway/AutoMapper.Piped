using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NUnit.Framework;
using Should;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Materialize.Tests2
{    
    [TestFixture]
    class CollectionTests : TestClassBase
    {
        //All a question of making appropriate CollectionFactories available

        [Test]
        public void MapsToIEnumerable() {
            MapsToCollection<IEnumerable<DogModel>>();
        }

        [Test]
        public void MapsToIEnumerableNonGen() {
            MapsToCollection<IEnumerable>();
        }
        
        [Test]
        public void MapsToArray() {
            MapsToCollection<DogModel[]>();
        }

        [Test]
        public void MapsToList() {
            MapsToCollection<List<DogModel>>();
        }
        
        [Test]
        public void MapsToIList() {
            MapsToCollection<IList<DogModel>>();
        }

        [Test]
        public void MapsToIListNonGen() {
            MapsToCollection<IList>();
        }
        
        [Test]
        public void MapsToICollection() {
            MapsToCollection<ICollection<DogModel>>();
        }

        [Test]
        public void MapsToICollectionNonGen() {
            MapsToCollection<ICollection>();
        }

        [Test]
        public void MapsToISet() {
            MapsToCollection<ISet<DogModel>>();
        }

        [Test]
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

            var ownerModels = people.MapAs<DogOwnerModel<TColl>>()
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

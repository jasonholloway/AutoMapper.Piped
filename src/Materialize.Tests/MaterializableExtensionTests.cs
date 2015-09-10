using Materialize.Tests.Infrastructure;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializableExtensionTests : TestClassBase
    {
        [Fact]
        public void First() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .Skip(50)
                                    .MaterializeAs<float>()
                                    .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var first = materializable.First();

            first.ShouldEqual(100F);
            fetchedItemsCount.ShouldEqual(1);
        }
                
        [Fact]
        public void FirstThrowsFamiliarException() {
            throw new NotImplementedException();
        }



        [Fact]
        public void FirstOrDefault() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Single() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            var ints = Enumerable.Range(0, 100).AsQueryable();
            
            int fetchedItemsCount = 0;

            var floats = ints.Skip(10).Take(1)
                                .MaterializeAs<float>()
                                .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var single = floats.Single();
            
            single.ShouldEqual(20F);
            fetchedItemsCount.ShouldEqual(1);
        }


        [Fact]
        public void SingleThrowsFamiliarException() 
        {
            //this is the provider's business, not ours...
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            var ints = Enumerable.Range(0, 100).AsQueryable();
            
            var manyFloats = ints.MaterializeAs<float>();
            
            Assert.Throws<InvalidOperationException>(() => manyFloats.Single());
        }


        [Fact]
        public void SingleOrDefault() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            var ints = Enumerable.Range(0, 100).AsQueryable();

            int fetchedItemsCount = 0;

            var floats = ints.Skip(10).Take(1)
                                .MaterializeAs<float>()
                                .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var single = floats.SingleOrDefault();
                        
            single.ShouldEqual(20F);
            fetchedItemsCount.ShouldEqual(1);
        }



        [Fact]
        public void SingleOrDefaultReturnsDefaultIfSequenceEmpty() {
            //this is the provider's business, not ours...

            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>().ProjectUsing(i => 2F * i);
            });

            var emptyInts = Enumerable.Range(0, 0).AsQueryable();
            
            var emptyFloats = emptyInts.MaterializeAs<float>();
            
            var result = emptyFloats.SingleOrDefault();

            result.ShouldEqual(default(float));
        }



        [Fact]
        public void Last() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .MaterializeAs<float>()
                                    .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var last = materializable.Last();

            last.ShouldEqual(198F);
            fetchedItemsCount.ShouldEqual(1);
        }

        [Fact]
        public void LastThrowsFamiliarException() {
            throw new NotImplementedException();
        }

        [Fact]
        public void LastOrDefault() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Take() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var ints = Enumerable.Range(0, 100).AsQueryable();

            var materializable = ints.MaterializeAs<float>()
                                        .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var taken = materializable.Take(10).ToArray();

            taken.Length.ShouldEqual(10);
            taken.SequenceEqual(ints.Take(10).Select(i => 2F * i)).ShouldBeTrue();
            fetchedItemsCount.ShouldEqual(10);
        }


        [Fact]
        public void Skip() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var ints = Enumerable.Range(0, 100).AsQueryable();

            var materializable = ints.MaterializeAs<float>()
                                        .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var taken = materializable.Skip(90).ToArray();

            taken.Length.ShouldEqual(10);
            taken.SequenceEqual(ints.Skip(90).Select(i => 2F * i)).ShouldBeTrue();
            fetchedItemsCount.ShouldEqual(10);
        }


        [Fact]
        public void Count() {
            throw new NotImplementedException();
        }

    }
}

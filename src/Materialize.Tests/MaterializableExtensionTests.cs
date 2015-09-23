using Materialize.Tests.Infrastructure;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializableExtensionTests : TestClassBase
    {
        public MaterializableExtensionTests() 
        {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, string>()
                    .ProjectUsing(i => i.ToString());
            });
        }
                
        IMaterializable<string> Range(int start, int count) {
            var ints = Enumerable.Range(start, count);
            return ints.AsQueryable().MaterializeAs<string>();
        }






        [Fact]
        public void First() {
            var first = Range(50, 100)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(1))
                            .First();

            first.ShouldEqual("50");       
        }
         
        [Fact]
        public void FirstThrows() {
            Assert.Throws<InvalidOperationException>(() => Range(199, 0).First());
        }
        
        


        [Fact]
        public void FirstOrDefault() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Single() {
            var single = Range(10, 1)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(1))
                            .Single();

            single.ShouldEqual("10");
        }


        [Fact]
        public void SingleThrows() 
        {            
            Assert.Throws<InvalidOperationException>(() => Range(0, 10).Single());
        }


        [Fact]
        public void SingleOrDefault() 
        {
            var single = Range(1, 1)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(1))
                            .SingleOrDefault();

            single.ShouldEqual("1");
        }



        [Fact]
        public void SingleOrDefaultReturnsDefault() 
        {
            var result = Range(1, 0)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(0))
                            .SingleOrDefault();

            result.ShouldEqual(default(string));
        }


    

        [Fact]
        public void Last() {
            var first = Range(50, 100)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(1))
                            .First();

            first.ShouldEqual("149");
        }

        [Fact]
        public void LastThrows() {
            Assert.Throws<InvalidOperationException>(() => Range(20, 0).Last());
        }

        [Fact]
        public void LastOrDefault() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Take() 
        {
            var result = Range(100, 50)                            
                            .Take(10)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(10))
                            .ToArray();

            result.Length.ShouldEqual(10);

            result.SequenceEqual(
                            Enumerable.Range(100, 10).Select(i => i.ToString())
                        ).ShouldBeTrue();
        }
                


        [Fact]
        public void Skip() 
        {
            var result = Range(100, 50)
                            .Skip(10)
                            .SnoopOnFetched(f => f.Count().ShouldEqual(40))
                            .ToArray();

            result.Length.ShouldEqual(40);

            result.SequenceEqual(
                            Enumerable.Range(110, 40).Select(i => i.ToString())
                        ).ShouldBeTrue();
        }


        [Fact]
        public void Count() {
            throw new NotImplementedException();
        }


        

        [Fact]
        public void Where() {
            var result = Range(0, 50)
                            .Where(s => s.Length == 1)
                            .ToArray();

            result.Length.ShouldEqual(10);

            result.SequenceEqual(
                            Enumerable.Range(0, 10).Select(i => i.ToString())
                        ).ShouldBeTrue();            
        }


        [Fact]
        public void WhereFirst() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var ints = Enumerable.Range(0, 100).AsQueryable();

            var materializable = ints.MaterializeAs<float>()
                                        .SnoopOnFetched(items => fetchedItemsCount += items.Count());

            var taken = materializable
                            .Where(f => f > 100F)
                            .First();

            taken.ShouldEqual(102F);

            Assert.Throws<InvalidOperationException>(() => {
                materializable
                        .Where(f => false)
                        .First();
            });
        }


        [Fact]
        public void WhereFirstOrDefault() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });
            
            var ints = Enumerable.Range(0, 100).AsQueryable();

            var materializable = ints.MaterializeAs<float>();
            
            var result1 = materializable
                            .Where(f => f > 100F)
                            .FirstOrDefault();

            result1.ShouldEqual(102F);


            var result2 = materializable
                            .Where(f => false)
                            .FirstOrDefault();

            result2.ShouldEqual(default(float));

        }



    }
}

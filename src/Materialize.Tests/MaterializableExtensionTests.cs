using Materialize.Tests.Infrastructure;
using Should;
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
            base.Initialize(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .Skip(50)
                                    .MaterializeAs<float>()
                                    .Snoop(e => fetchedItemsCount += e.OfType<object>().Count());

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
            throw new NotImplementedException();
        }

        [Fact]
        public void SingleThrowsFamiliarException() {
            throw new NotImplementedException();
        }


        [Fact]
        public void SingleOrDefault() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Last() {
            base.Initialize(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });

            int fetchedItemsCount = 0;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .MaterializeAs<float>()
                                    .Snoop(e => fetchedItemsCount += e.OfType<object>().Count());

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
            throw new NotImplementedException();
        }

        [Fact]
        public void Skip() {
            throw new NotImplementedException();
        }


        [Fact]
        public void Count() {
            throw new NotImplementedException();
        }

    }
}

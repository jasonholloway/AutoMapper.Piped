using Materialize.Tests.Infrastructure;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests2
{
    [TestFixture]    
    class ParsingCombinations : TestClassBase
    {
        public ParsingCombinations() 
        {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, string>()
                    .ProjectUsing(i => i.ToString());
            });

            Fetched = Enumerable.Empty<object>();
        }


        IEnumerable<object> Fetched { get; set; }


        IQueryable<string> Range(int start, int count) {
            var snooper = new EventSnooper();
            snooper.Fetched += (en => Fetched = en);
                        
            var ints = Enumerable.Range(start, count);
            return ints.AsQueryable().MapAs<string>(snooper);
        }



        
        
               

        [Test]
        public void WhereFirst() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });
            
            var ints = Enumerable.Range(0, 100).AsQueryable();

            var qyMapped = ints.MapAs<float>();

            var taken = qyMapped.Where(f => f > 100F)
                                .First();

            taken.ShouldEqual(102F);

            Assert.Throws<InvalidOperationException>(() => {
                qyMapped.Where(f => false)
                        .First();
            });
        }


        [Test]
        public void WhereFirstOrDefault() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => 2F * i);
            });
            
            var ints = Enumerable.Range(0, 100).AsQueryable();

            var qyMapped = ints.MapAs<float>();
            
            var result1 = qyMapped
                            .Where(f => f > 100F)
                            .FirstOrDefault();

            result1.ShouldEqual(102F);


            var result2 = qyMapped
                            .Where(f => false)
                            .FirstOrDefault();

            result2.ShouldEqual(default(float));

        }



    }
}

using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NUnit.Framework;
using Should;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests.Outer
{
    [TestFixture]    
    class ParsingAggregators : TestClassBase
    {
                
        public ParsingAggregators() 
        {
            InitMapper(x => {
                x.CreateMap<Source, Mapped>();
            });

            Fetched = Enumerable.Empty<object>();
        }


        IEnumerable<object> Fetched { get; set; }



        class Source
        {
            public int Value { get; set; }
        }

        class Mapped
        {
            public int Value { get; set; }
        }



        IQueryable<Mapped> Range(int start, int count) 
        {
            var snooper = new EventSnooper();
            snooper.Fetched += (f => Fetched = f is IEnumerable ? (IEnumerable<object>)f : new[] { f });
                        
            var ints = Enumerable.Range(start, count);
            
            return ints.Select(i => new Source() { Value = i })
                            .AsQueryable()
                            .MapAs<Mapped>(snooper);
        }



        

        [Test]
        public void CountOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Where(m => true)
                            .Count();

            Assert.That(result, Is.EqualTo(50));
        }


        [Test]
        public void CountOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Count();

            Assert.That(result, Is.EqualTo(50));
        }



        [Test]
        public void CountWithPredicateOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            }); 

            var result = Range(0, 50)
                            .Count(m => m.Value < 10);

            Assert.That(result, Is.EqualTo(10));
        }


        [Test]
        public void CountWithPredicateOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Count(m => m.Value < 10);

            Assert.That(result, Is.EqualTo(10));
        }

        

    }
}

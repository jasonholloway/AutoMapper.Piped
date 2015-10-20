using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests2
{
    [TestFixture]    
    class ParsingQuantifiers : TestClassBase
    {
        
        public ParsingQuantifiers() 
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
            snooper.Fetched += (f => Fetched = (IEnumerable<object>)f);
                        
            var ints = Enumerable.Range(start, count);

            return ints.Select(i => new Source() { Value = i })
                            .AsQueryable()
                            .MapAs<Mapped>(snooper);
        }



        [Test]
        public void AnyOnClient() {
            throw new NotImplementedException();
        }


        [Test]
        public void AnyOnServer() {
            throw new NotImplementedException();
        }




        [Test]
        public void AnyWithPredicateOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Any(m => m.Value > 10);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .Any(m => m.Value > 50);

            Assert.That(result, Is.False);
        }


        [Test]
        public void AnyWithPredicateOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Any(m => m.Value > 10);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .Any(m => m.Value > 50);

            Assert.That(result, Is.False);
        }



        [Test]
        public void AllOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .All(m => m.Value < 60);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .All(m => m.Value > 50);

            Assert.That(result, Is.False);
        }


        [Test]
        public void AllOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .All(m => m.Value < 60);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .All(m => m.Value > 50);

            Assert.That(result, Is.False);
        }

    }
}

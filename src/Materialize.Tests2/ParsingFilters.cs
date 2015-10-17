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
    class ParsingFilters : TestClassBase
    {
        
        public ParsingFilters() 
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
            snooper.Fetched += (en => Fetched = en);
                        
            var ints = Enumerable.Range(start, count);

            return ints.Select(i => new Source() { Value = i })
                            .AsQueryable()
                            .MapAs<Mapped>(snooper);
        }
               


        [Test]
        public void WhereOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Where(m => m.Value < 10 && m.Value > 5)
                            .ToArray();
            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(6, 4)));            
        }


        [Test]           
        public void WhereOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Where(m => m.Value < 10 && m.Value > 5)
                            .ToArray();
            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(6, 4)));
        }

        


        [Test]
        public void FirstWithPredicateOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .First(m => m.Value > 10)
                            .Value;

            Assert.That(result, Is.EqualTo(11));
        }


        [Test]
        public void FirstWithPredicateOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .First(m => m.Value > 10)
                            .Value;

            Assert.That(result, Is.EqualTo(11));
        }


        [Test]
        public void LastWithPredicateOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Last(m => m.Value < 10)
                            .Value;

            Assert.That(result, Is.EqualTo(9));
        }


        [Test]
        public void LastWithPredicateOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(0, 50)
                            .Last(m => m.Value < 10)
                            .Value;

            Assert.That(result, Is.EqualTo(9));
        }






    }
}

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
        public void WhereOnClient() 
        {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .Where(m => m.Value < 10)
                            .ToArray();
            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(0, 10)));            
        }


        [Test]           
        public void WhereOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .Where(m => m.Value < 10)
                            .ToArray();
            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(0, 10)));
        }



        [Test]
        public void CountWithPredicateOnClient() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .Count(m => m.Value < 10);

            Assert.That(result, Is.EqualTo(10));
        }


        [Test]
        public void CountWithPredicateOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .Count(m => m.Value < 10);

            Assert.That(result, Is.EqualTo(10));
        }


        [Test]
        public void FirstWithPredicateOnClient() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .First(m => m.Value > 10)
                            .Value;

            Assert.That(result, Is.EqualTo(11));
        }


        [Test]
        public void FirstWithPredicateOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .First(m => m.Value > 10)
                            .Value;

            Assert.That(result, Is.EqualTo(11));
        }


        [Test]
        public void LastWithPredicateOnClient() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .Last(m => m.Value < 10)
                            .Value;

            Assert.That(result, Is.EqualTo(9));
        }


        [Test]
        public void LastWithPredicateOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .Last(m => m.Value < 10)
                            .Value;

            Assert.That(result, Is.EqualTo(9));
        }





        [Test]
        public void AnyWithPredicateOnClient() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .Any(m => m.Value > 10);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .Any(m => m.Value > 50);

            Assert.That(result, Is.False);
        }


        [Test]
        public void AnyWithPredicateOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .Any(m => m.Value > 10);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .Any(m => m.Value > 50);

            Assert.That(result, Is.False);
        }



        [Test]
        public void AllOnClient() {
            InitServices(x => x.EmplaceIntolerantSourceRegime());
            InitServices(x => x.AllowClientSideFiltering());

            var result = Range(0, 50)
                            .All(m => m.Value < 60);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .All(m => m.Value > 50);

            Assert.That(result, Is.False);
        }


        [Test]
        public void AllOnServer() {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            InitServices(x => x.ForbidClientSideFiltering());

            var result = Range(0, 50)
                            .All(m => m.Value < 60);

            Assert.That(result, Is.True);


            result = Range(0, 50)
                        .All(m => m.Value > 50);

            Assert.That(result, Is.False);
        }



    }
}

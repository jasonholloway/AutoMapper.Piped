using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests.Outer
{
    [TestFixture]    
    class ParsingPartitioners : TestClassBase
    {
        
        public ParsingPartitioners() 
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
        public void TakeOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(100, 50)
                            .Take(10)
                            .ToArray();

            Assert.That(Fetched.Count(), Is.EqualTo(result.Length));            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(100, 10)));
        }



        [Test]
        public void SkipOnServer() {
            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            var result = Range(100, 50)
                            .Skip(10)
                            .ToArray();
            
            Fetched.Count().ShouldEqual(result.Length);
            
            Assert.That(result.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(110, 40)));            
        }



        [Test]
        public void TakeOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            throw new NotImplementedException();
        }


        [Test]
        public void SkipOnClient() {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            throw new NotImplementedException();
        }
                        

    }
}

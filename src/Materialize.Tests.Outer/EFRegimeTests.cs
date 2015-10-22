using Materialize.SourceRegimes;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Should;
using NUnit.Framework;

namespace Materialize.Tests.Outer
{
    [TestFixture]
    class EFRegimeTests : TestClassBase
    {
        IQueryable<Dog> Dogs;

        public EFRegimeTests() {
            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
            });
        }




        [Test]
        public void DetectsRegimeFromQuery() {            
            using(var ctx = new Context()) {
                var regimeProv = new EF6RegimeProvider();

                regimeProv.GetRegime(ctx.Dogs).ShouldNotBeNull();
                regimeProv.GetRegime(new int[3].AsQueryable()).ShouldBeNull();
            }
        }

               

        [Test]
        public void CreatingMappedEntitiesIsForbidden() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                
                regime.AssertDeclines(() => new Dog());
            }
        }


        [Test]
        public void CreatingUnmappedEntitiesIsAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertAccepts(() => new DogModel());
            }
        }


        [Test]
        public void CreatingSimpleTypesIsAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertAccepts(Expression.New(typeof(float)));
            }
        }



        class ClassWithParameterizedCtor
        {
            public ClassWithParameterizedCtor(int i) { }
        }


        [Test]
        public void ParameterizedCtorsForbidden() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertDeclines(() => new ClassWithParameterizedCtor(13));

                regime.AssertDeclines(() => new ClassWithVariousCtors(44));
            }
        }




        class ClassWithVariousCtors
        {
            public ClassWithVariousCtors() { }
            public ClassWithVariousCtors(int i) { }
        }

        [Test]
        public void NonParameterizedCtorsAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertAccepts(() => new ClassWithVariousCtors());
            }
        }








        [Test]
        public void NonEdmMethodsForbidden() 
        {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                
                regime.AssertDeclines(() => this.NonEdmMethodsForbidden());
            }   
        }











        [Test]
        public void MappedMemberAccessesAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                                
                regime.AssertAccepts(() => ctx.Dogs.FirstOrDefault().Name);
            }
        }


        [Test]
        public void UnmappedMemberAccessesForbidden() {                        
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertDeclines(() => new DogModel().Name);
            }
        }




        [Test]
        public void TakesLambdasAsParamBindingScopes() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                var exParam = Expression.Parameter(typeof(int));

                regime.AssertAccepts(Expression.Lambda(exParam, exParam));
            }
        }




        [Test]
        public void WorksWithPredicateRebasing() {
            InitServices(x => {
                x.EmplaceSourceRegimeProvider(new EF6RegimeProvider());
            });

            using(var ctx = new Context()) {
                var r = ctx.Dogs.MapAs<DogModel>()
                                .Where(m => m.Name.Length > 4)
                                .ToArray();

            }
        }



        
    }
}

using Materialize.SourceRegimes;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Should;
using Should.Core.Assertions;

namespace Materialize.Tests
{
    class MaterializationEFRegimeTests : TestClassBase
    {
        IQueryable<Dog> Dogs;

        public MaterializationEFRegimeTests() {
            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
            });
        }




        [Fact]
        public void DetectsRegimeFromQuery() {            
            using(var ctx = new Context()) {
                var regimeProv = new EF6RegimeProvider();

                regimeProv.GetRegime(ctx.Dogs).ShouldNotBeNull();
                regimeProv.GetRegime(new int[3].AsQueryable()).ShouldBeNull();
            }
        }


        
        [Fact]
        public void CachedRegimeIsUsedForSameContextType() {
            var regimeProv = new EF6RegimeProvider();
            
            using(var ctx1 = new Context()) {
                using(var ctx2 = new Context()) {
                    regimeProv.GetRegime(ctx1.Dogs)
                        .ShouldEqual(regimeProv.GetRegime(ctx2.Dogs));
                }
            }
        }


        [Fact]
        public void FreshRegimeIsUsedForNewContextType() {
            throw new NotImplementedException();
        }


        [Fact]
        public void CreatingMappedEntitiesIsForbidden() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                
                regime.AssertDeclines(() => new Dog());
            }
        }


        [Fact]
        public void CreatingUnmappedEntitiesIsAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertAccepts(() => new DogModel());
            }
        }


        [Fact]
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


        [Fact]
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

        [Fact]
        public void NonParameterizedCtorsAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertAccepts(() => new ClassWithVariousCtors());
            }
        }








        [Fact]
        public void NonEdmMethodsForbidden() 
        {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                
                regime.AssertDeclines(() => this.NonEdmMethodsForbidden());
            }   
        }











        [Fact]
        public void MappedMemberAccessesAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                                
                regime.AssertAccepts(() => ctx.Dogs.FirstOrDefault().Name);
            }
        }


        [Fact]
        public void UnmappedMemberAccessesForbidden() {                        
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertDeclines(() => new DogModel().Name);
            }
        }



        
    }
}

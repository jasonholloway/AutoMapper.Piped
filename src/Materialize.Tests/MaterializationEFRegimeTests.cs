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
            InitServices(x => {
                x.Register<ISourceRegimeProvider, EF6RegimeProvider>();
            });

            using(var ctx = new Context()) {
                Assert.DoesNotThrow(() => {
                    ctx.Dogs.MapAs<DogModel>()
                                .Where(d => d.Name.Length < 5)
                                .ToArray();
                });
            }
        }


        [Fact]
        public void CachedRegimeIsUsedForSameMetadata() {
            throw new NotImplementedException();
        }


        [Fact]
        public void FreshRegimeIsUsedForNewMetadata() {
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

                regime.AssertAccepts(() => new float());
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
        public void OnlyEdmMethodsAccepted() 
        {
            using(var ctx = new Context()) {
                var objCtx = ((IObjectContextAdapter)ctx).ObjectContext;

                var metadata = objCtx.MetadataWorkspace;
                
                var items = metadata.GetItems(DataSpace.CSpace);
                                
            }   

            throw new NotImplementedException();
        }











        [Fact]
        public void MappedMemberAccessesAllowed() {
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);
                                
                regime.AssertAccepts(() => ctx.Dogs.First().Name);
            }
        }


        [Fact]
        public void UnmappedMemberAccessesForbidden() {                        
            using(var ctx = new Context()) {
                var regime = new EF6Regime(ctx);

                regime.AssertDeclines(() => new DogModel().Name);
            }
        }



        [Fact]
        public void CantProjectToMappedEntities() {
            //this is special case: needs to be treated like custom projection behind the scenes
            //...

            throw new NotImplementedException();
        }


    }
}

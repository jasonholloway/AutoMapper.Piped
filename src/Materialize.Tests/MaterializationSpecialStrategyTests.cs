using Materialize.SourceRegimes;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NSubstitute;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Materialize.Tests
{
    class MaterializationSpecialStrategyTests : TestClassBase
    {
        [Fact]
        public void ProviderFriendlyProjectionsDoneByServer() 
        {
            Expression<Func<Person, PersonModel>> exPersonProj 
                                                    = (p) => new PersonModel() { Name = "Colin" };
            
            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>().ProjectUsing(exPersonProj);
            });

            InitServices(x => {
                var regime = Substitute.For<ISourceRegime>();
                regime.ServerAccepts(Arg.Any<Expression>()).Returns(true);

                var detector = Substitute.For<ISourceRegimeDetector>();
                detector.DetectRegime(Arg.Any<IQueryProvider>()).Returns(regime);

                x.Register(detector);
            });
            

            Expression queryExpression = null;
            
            var models = Data.Dogs.AsQueryable()
                                    .Snoop(ex => queryExpression = ex)
                                    .MaterializeAs<DogAndOwnerModel>()
                                    .ToArray();


            queryExpression.Contains(exPersonProj).ShouldBeTrue();
        }




        [Fact]
        public void ProviderUnfriendlyProjectionsDoneByClient() 
        {
            Expression<Func<Person, PersonModel>> exPersonProj
                                                    = (p) => new PersonModel() { Name = "Colin" };

            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>().ProjectUsing(exPersonProj);
            });

            InitServices(x => {
                var regime = Substitute.For<ISourceRegime>();
                regime.ServerAccepts(Arg.Any<Expression>()).Returns(false);

                var detector = Substitute.For<ISourceRegimeDetector>();
                detector.DetectRegime(Arg.Any<IQueryProvider>()).Returns(regime);

                x.Register(detector);
            });


            Expression queryExpression = null;

            var models = Data.Dogs.AsQueryable()
                                    .Snoop(ex => queryExpression = ex)
                                    .MaterializeAs<DogAndOwnerModel>()
                                    .ToArray();


            queryExpression.Contains(exPersonProj).ShouldBeFalse();
        }







        [Fact]
        public void OnlyValuesNeededForProjectionAreFetched() {
            throw new NotImplementedException();
        }
        
        [Fact]
        public void CanMapToContextEntites() {
            //this is special case: needs to be treated like custom projection behind the scenes
            //...

            throw new NotImplementedException();
        }

    }
}

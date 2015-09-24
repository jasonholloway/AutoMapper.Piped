using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Materialize.Tests
{
    class MaterializationTranslationTests : TestClassBase
    {
        [Fact]
        public void ProviderFriendlyProjectionsDoneByServer() {
            Expression<Func<Person, PersonModel>> exPersonProj
                                                    = (p) => new PersonModel() { Name = "Colin" };

            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>().ProjectUsing(exPersonProj);
            });

            InitServices(x => {
                x.EmplaceTolerantSourceRegime();
            });


            Expression exServerQuery = null;

            var snooper = new Snooper();
            snooper.QueryToServer += (qy => exServerQuery = qy.Expression);


            var models = Data.Dogs.AsQueryable()                                    
                                    .MapAs<DogAndOwnerModel>(snooper)
                                    .ToArray();
            
            exServerQuery.Contains(exPersonProj.Body).ShouldBeTrue();
        }




        [Fact]
        public void ProviderUnfriendlyProjectionsDoneByClient() {
            Expression<Func<Person, PersonModel>> exPersonProj
                                                    = (p) => new PersonModel() { Name = "Colin" };

            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>().ProjectUsing(exPersonProj);
            });

            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
            });


            Expression exServerQuery = null;

            var snooper = new Snooper();
            snooper.QueryToServer += (qy => exServerQuery = qy.Expression);

            var dogModels = Data.Dogs.AsQueryable()
                                        .MapAs<DogAndOwnerModel>(snooper)
                                        .ToArray();


            exServerQuery.Contains(exPersonProj.Body)
                                        .ShouldBeFalse();

            dogModels.Select(d => d.Owner.Name)
                        .All(n => n == "Colin")
                        .ShouldBeTrue();
        }
        

        [Fact]
        public void OnlyValuesNeededForProjectionAreFetched() {
            throw new NotImplementedException();
        }
        
    }
}

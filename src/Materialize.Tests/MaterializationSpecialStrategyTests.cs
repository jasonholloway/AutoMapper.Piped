using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{
    class MaterializationSpecialStrategyTests : TestClassBase
    {
        [Fact]
        public void ProviderFriendlyProjectionsDoneByServer() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Person, PersonModel>()
                    .ProjectUsing(p => new PersonModel() { Name = "Colin" });
            });

            


            //should mock expression tester, so wouldn't just be edm, but would
            //be provider-dependent


            throw new NotImplementedException();
        }

        [Fact]
        public void ProviderUnfriendlyProjectionsDoneByClient() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Person, PersonModel>()
                    .ProjectUsing(p => new PersonModel() { Name = "Colin" });
            });

            throw new NotImplementedException();
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

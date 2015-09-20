using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializableRebaseTests : TestClassBase
    {
        public MaterializableRebaseTests() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>();
            });
        }
                
        IMaterializable<string> Range(int start, int count) {
            var ints = Enumerable.Range(start, count);
            return ints.AsQueryable().MaterializeAs<string>();
        }


        [Fact]
        public void ATest() {
            var dogs = Data.Dogs.AsQueryable()
                        .MaterializeAs<DogAndOwnerModel>();

            var result = dogs.Where(d => d.Owner.Name == "Brian").First();

            throw new NotImplementedException();
        }





        

    }
}

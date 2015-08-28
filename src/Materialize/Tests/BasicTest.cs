using AutoMapper;
using FizzWare.NBuilder;
using Should;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoMapper.QueryableExtensions;

namespace Materialize.Tests
{
    public class BasicTests
    {        
        [Fact]
        public void ShallowPropertyMapping() {
            Mapper.Initialize(x => {
                x.CreateMap<Dog, DogModel>();
            });

            using(var ctx = new Context()) {
                ctx.Dogs.ShouldNotBeEmpty();
                
                var dogModels = ctx.Dogs.MaterializeAs<DogModel>();
                dogModels.ShouldNotBeEmpty();

                dogModels.Zip(
                        ctx.Dogs,
                        (m, d) => new {
                            DogModel = m,
                            Dog = d
                        }).All(t => t.Dog.Name == t.DogModel.Name)
                            .ShouldBeTrue();
            }
        }


        [Fact]
        public void ShallowProjection() {
            Mapper.Initialize(x => {
                x.CreateMap<Dog, DogModel>()
                    .ProjectUsing(d => new DogModel() { Name = d.Name.ToUpper() });
            });

            using(var ctx = new Context()) {
                var dogModels = ctx.Dogs.MaterializeAs<DogModel>();
                dogModels.ShouldNotBeEmpty();

                dogModels.Zip(
                            ctx.Dogs,
                            (m, d) => new {
                                Model = m,
                                Dog = d
                            }).All(t => t.Dog.Name.ToUpper() == t.Model.Name)
                                .ShouldBeTrue();
            }
        }





        [Fact]
        public void CanMapToContextEntites() {
            //this is special case: needs to be treated like custom projection behind the scenes
            //...

            throw new NotImplementedException();
        }


        [Fact]
        public void InjectsEdmFriendlyProjections() {
            throw new NotImplementedException();
        }
        

        [Fact]
        public void ReturnsIMaterializableAndDoesntFetchTillMaterialized() {
            throw new NotImplementedException();
        }

    }
}

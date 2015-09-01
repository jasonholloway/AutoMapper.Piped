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
        public void ShallowPropertyMapping() 
        {
            ReifierSource.Default.Reset(); //This should somehow be triggered by Mapper.Initialize!

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
        public void ShallowProjection() 
        {
            ReifierSource.Default.Reset(); //This should somehow be triggered by Mapper.Initialize!

            Mapper.Initialize(x => {
                x.CreateMap<Dog, DogModel>()
                    .ProjectUsing(d => new DogModel() { Name = d.Name.ToUpper() });
            });

            using(var ctx = new Context()) {
                var dogs = ctx.Dogs.ToArray();

                var dogModels = ctx.Dogs
                                    .MaterializeAs<DogModel>()
                                    .ToArray();

                dogModels.ShouldNotBeEmpty();

                dogs.Zip(dogModels,
                            (d, m) => new {
                                Dog = d,
                                Model = m
                            })
                            .All(t => t.Dog.Name.ToUpper() == t.Model.Name)
                                .ShouldBeTrue();
            }
        }

        [Fact]
        public void SimplePropertyMapsCascade() 
        {
            ReifierSource.Default.Reset(); //This should somehow be triggered by Mapper.Initialize!

            Mapper.Initialize(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>();
            });

            using(var ctx = new Context()) {
                var dogs = ctx.Dogs
                                .Include(d => d.Owner)
                                .ToArray();

                var dogModels = ctx.Dogs
                                    .Include(d => d.Owner)
                                    .MaterializeAs<DogAndOwnerModel>()
                                    .ToArray();

                dogs.Zip(dogModels,
                            (d, m) => new {
                                Dog = d,
                                Model = m
                            })
                            .All(t => t.Dog.Owner.Name == t.Model.Owner.Name)
                                .ShouldBeTrue();
            }
        }

        [Fact]
        public void PropertyMapsCascadeToProjections() 
        {
            //Doesn't work yet cos SimplePropertyMapper used even though inputs have been projected
            //MediatedPropertyMapper needs to step in, to project to tuple.
            //...

            ReifierSource.Default.Reset(); //This should somehow be triggered by Mapper.Initialize!

            Mapper.Initialize(x => {
                x.CreateMap<Dog, DogModel>();

                x.CreateMap<DogGroomer, DogGroomerModel>();

                x.CreateMap<decimal, Fee>()
                    .ProjectUsing(d => new Fee(d));

                x.CreateMap<Contract, ContractModel>();
            });

            using(var ctx = new Context()) {
                var qyContracts = ctx.Contracts
                                    .Include(c => c.Dog)
                                    .Include(c => c.Groomer);

                var contracts = qyContracts.ToArray();

                var contractModels = qyContracts
                                        .MaterializeAs<ContractModel>()
                                        .ToArray();
                                
                contracts.Zip(contractModels,
                            (c, m) => new {
                                Contract = c,
                                Model = m
                            })
                            .All(t => t.Contract.Fee == t.Model.Fee.Amount)
                                .ShouldBeTrue();
            }
        }


        [Fact]
        public void OnlyValuesNeededForProjectionAreFetched() {
            throw new NotImplementedException();
        }


        [Fact]
        public void EdmFriendlyProjectionsDoneByServer() {
            throw new NotImplementedException();
        }



        [Fact]
        public void CircuitousGraphsHandled() {
            throw new NotImplementedException();
        }

        [Fact]
        public void OnlyMapsToSetDepth() {
            throw new NotImplementedException();
        }
        
                
        [Fact]
        public void CanMapToContextEntites() {
            //this is special case: needs to be treated like custom projection behind the scenes
            //...

            throw new NotImplementedException();
        }



        [Fact]
        public void ReturnsIMaterializableAndDoesntFetchTillMaterialized() {
            throw new NotImplementedException();
        }

    }
}

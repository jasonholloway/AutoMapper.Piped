using AutoMapper;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using System;
using System.Data.Entity;
using System.Linq;
using Xunit;

namespace Materialize.Tests
{
    class MaterializationBasicTests : TestClassBase
    {        
        [Fact]
        public void ShallowPropertyMapping() 
        {
            InitServices();

            InitMapper(x => {
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
            InitServices();
               
            InitMapper(x => {
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
            InitServices();

            InitMapper(x => {
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
        public void PropertyMapsAccommodateMemberProjections() 
        {
            InitServices();

            InitMapper(x => {
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

                var contracts = qyContracts
                                        .ToArray();

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
        public void FetchesOnlyWhenEnumerated() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => i);
            });

            bool fetched = false;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .Snoop(_ => fetched = true)
                                    .MaterializeAs<float>();

            fetched.ShouldBeFalse();

            var result = materializable.AsEnumerable();

            fetched.ShouldBeFalse();

            result.Count();

            fetched.ShouldBeTrue();
        }


        [Fact]
        public void MaterializablesFetchOnceOnly() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => i);
            });

            int fetchCount = 0;

            var materializable = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .Snoop(_ => fetchCount++)
                                    .MaterializeAs<float>();

            for(int i = 0; i < 10; i++) {
                materializable.Count();
            }

            fetchCount.ShouldEqual(1);
        }

        







        [Fact]
        public void MaterializablesAreThreadSafe() {
            //lock on fetching, and on any decisions made on fetch status
            //...

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
        public void WorksWithNonGenericCollections() {
            throw new NotImplementedException();
        }

        [Fact]
        public void WorksWithNonGenericQueryables() {
            throw new NotImplementedException();
        }


    }
}

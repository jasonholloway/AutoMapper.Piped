using AutoMapper;
using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using NUnit.Framework;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Materialize.Tests2
{
    [TestFixture]
    class BasicTests : TestClassBase
    {        
        [Test]
        public void ShallowPropertyMapping() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
            });

            var dogs = Data.Dogs.AsQueryable();

            var dogModels = dogs.MapAs<DogModel>()
                                    .ToArray();

            dogModels.ShouldNotBeEmpty();

            dogModels.Zip(
                    dogs,
                    (m, d) => new {
                        DogModel = m,
                        Dog = d
                    }).All(t => t.Dog.Name == t.DogModel.Name)
                        .ShouldBeTrue();            
        }



        class DogWithFieldsModel
        {
            public int Age;
            public string Name;
        }

        [Test]
        public void PropertyMappingMapsToFields() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogWithFieldsModel>();
            });

            var mapped = Data.Dogs.AsQueryable()
                                    .MapAs<DogWithFieldsModel>()
                                    .Where(m => m.Age > 10)
                                    .ToArray();
            
            Assert.That(
                    Data.Dogs.Where(d => d.Age > 10).Select(d => d.Name),
                    Is.EquivalentTo(mapped.Select(d => d.Name)));
        }






        class Source
        {
            public int Value;
        }

        class Mapped
        {
            public int Value { get; set; }
        }


        [Test]
        public void PropertyMappingMapsFromFields() {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Source, Mapped>();
            });

            var mapped = Enumerable.Range(0, 50)
                                    .Select(i => new Source() { Value = i })
                                    .AsQueryable()
                                    .MapAs<Mapped>().ToArray();
                       
            Assert.That(mapped.Select(m => m.Value), Is.EquivalentTo(Enumerable.Range(0, 50)));
        }








        [Test]
        public void ShallowProjection() 
        {
            InitServices();
               
            InitMapper(x => {
                x.CreateMap<Dog, DogModel>()
                    .ProjectUsing(d => new DogModel() { Name = d.Name.ToUpper() });
            });

            var dogs = Data.Dogs.AsQueryable();

            var dogModels = dogs.MapAs<DogModel>()
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

        [Test]
        public void SimplePropertyMapsCascade() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonModel>();
            });

            var dogs = Data.Dogs.AsQueryable();

            var dogModels = dogs.MapAs<DogAndOwnerModel>()
                                    .ToArray();

            dogs.Zip(dogModels,
                        (d, m) => new {
                            Dog = d,
                            Model = m
                        })
                        .All(t => t.Dog.Owner.Name == t.Model.Owner.Name)
                        .ShouldBeTrue();
        }
        

        [Test]
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
            
            var contracts = Data.Contracts.AsQueryable();

            var contractModels = contracts.MapAs<ContractModel>()
                                            .ToArray();
                                
            contracts.Zip(contractModels,
                        (c, m) => new {
                            Contract = c,
                            Model = m
                        })
                        .All(t => t.Contract.Fee == t.Model.Fee.Amount)
                        .ShouldBeTrue();
        }



        [Test]
        public void FetchesOnlyWhenEnumerated() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => i);
            });
            
            bool fetchedYet = false;

            var snoop = new EventSnooper();
            snoop.Fetched += (_ => fetchedYet = true);


            var mapped = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .MapAs<float>(snoop);

            
            fetchedYet.ShouldBeFalse();
            
            var result = mapped.AsEnumerable();

            fetchedYet.ShouldBeFalse();

            result.Count();

            fetchedYet.ShouldBeTrue();
        }


        [Test]
        public void MaterializablesFetchOnceOnly() 
        {
            InitServices();

            InitMapper(x => {
                x.CreateMap<int, float>()
                    .ProjectUsing(i => i);
            });

            int fetchCount = 0;

            var snooper = new EventSnooper();
            snooper.Fetched += (_ => fetchCount++);


            var mapped = Enumerable.Range(0, 100)
                                    .AsQueryable()
                                    .MapAs<float>(snooper);

            for(int i = 0; i < 10; i++) {
                mapped.ToArray();
            }

            fetchCount.ShouldEqual(1);
        }

        







        [Test]
        public void MaterializablesAreThreadSafe() {
            //lock on fetching, and on any decisions made on fetch status
            //...

            throw new NotImplementedException();
        }



        [Test]
        public void CircuitousGraphsHandled() {
            throw new NotImplementedException();
        }

        [Test]
        public void OnlyMapsToSetDepth() {
            throw new NotImplementedException();
        }
        
                
        

        [Test]
        public void ThrowsAutoMapperEquivalentExceptions() {
            throw new NotImplementedException();
        }
                

        [Test]
        public void MaterializeAsTakesAndRespectsOptions() {            
            throw new NotImplementedException();
        }

    }
}

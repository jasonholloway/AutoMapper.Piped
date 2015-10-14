using Materialize.Tests.Infrastructure;
using Materialize.Tests.Model;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Materialize.Tests
{    
    class MaterializableRebaseTests : TestClassBase
    {
        IQueryable<Dog> Dogs { get; set; }
        IQueryable<Person> People { get; set; }


        public MaterializableRebaseTests() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            InitMapper(x => {
                x.CreateMap<Dog, DogModel>();
                x.CreateMap<Dog, DogAndOwnerModel>();
                x.CreateMap<Person, PersonWithPetsModel>();
            });

            Dogs = Data.Dogs.AsQueryable();
            People = Data.People.AsQueryable();
        }
        
        
        [Fact]
        public void RebasesSimpleMappedProperties() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());
            
            var snoop = new ItemSnooper();
            
            var dogModels = Dogs.MapAs<DogModel>(snoop)
                                    .Where(m => m.Name.Length > 5)
                                    .ToArray();
            
            dogModels.Select(d => d.Name)
                        .SequenceEqual(Dogs.Where(d => d.Name.Length > 5).Select(d => d.Name))
                        .ShouldBeTrue();

            snoop.Fetched.Count().ShouldEqual(dogModels.Count());            
        }


        [Fact]
        public void UnrebasablePredicateFailsWhenClientFilteringForbidden() 
        {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.ForbidClientSideFiltering();
            });

            Assert.Throws<RebaseException>(() => {
                Dogs.MapAs<DogModel>()
                        .Where(m => m.Name == "Rex")                //currently failing cos server rejections handled differently (which is wrong)
                        .ToArray();                                 //if an exception was raised by the mapstrtaegy, all would be fine here...
            });
        }


        //fixing the above requires the server test to return an exception... which seems wrong, to be honest
        //exceptions not as messangers, please.  





        [Fact]
        public void UnrebasablePredicateAppliedOnClientInstead() 
        {
            InitServices(x => {
                x.EmplaceIntolerantSourceRegime();
                x.AllowClientSideFiltering();
            });

            var snoop = new ItemSnooper();
            
            Dogs.MapAs<DogModel>(snoop)
                    .Where(m => m.Name.Length > 4)
                    .ToArray();

            snoop.Fetched.Count().ShouldEqual(Dogs.Count());
            snoop.Transformed.Count().ShouldEqual(Dogs.Count(d => d.Name.Length > 4));
        }


        [Fact]
        public void RebasesEnumerableCount() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            var models = People.MapAs<PersonWithPetsModel>()
                                .Where(p => p.Dogs.Count() > 1)
                                .ToArray();

            models.Select(m => m.Name)
                    .SequenceEqual(People.Where(p => p.Dogs.Count() > 1)
                                            .Select(p => p.Name));
        }
        
        [Fact]
        public void RebasesEnumerableAny() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            var people = People.Concat(new[] {
                                            new Person() { Name = "Petless", Dogs = new Dog[0], ID = 999 }
                                        });

            var models = people.MapAs<PersonWithPetsModel>()
                                    .Where(p => p.Dogs.Any())
                                    .ToArray();

            models.Select(m => m.Name)
                    .SequenceEqual(people.Where(p => p.Dogs.Any())
                                            .Select(p => p.Name));
        }



        [Fact]
        public void RebasesEnumerableWhere() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            var models = People.MapAs<PersonWithPetsModel>()
                                .Where(p => p.Dogs.Where(d => d.Name.Length > 5).Any())
                                .ToArray();

            models.Select(m => m.Name)
                    .SequenceEqual(People.Where(p => p.Dogs.Where(d => d.Name.Length > 5).Any())
                                            .Select(p => p.Name));
        }


        [Fact]
        public void RebasesEnumerableAnyWithPredicate() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            var models = People.MapAs<PersonWithPetsModel>()
                                .Where(p => p.Dogs.Any(d => d.Name.Length > 5))
                                .ToArray();

            models.Select(m => m.Name)
                    .SequenceEqual(People.Where(p => p.Dogs.Any(d => d.Name.Length > 5))
                                            .Select(p => p.Name));
        }



        [Fact]
        public void RebasesEnumerableCountWithPredicate() 
        {
            InitServices(x => x.EmplaceTolerantSourceRegime());

            var models = People.MapAs<PersonWithPetsModel>()
                                .Where(p => p.Dogs.Count(d => d.Name.Length > 5) > 1)
                                .ToArray();

            models.Select(m => m.Name)
                    .SequenceEqual(People.Where(p => p.Dogs.Count(d => d.Name.Length > 5) > 1)
                                            .Select(p => p.Name));
        }



    }
}

using FizzWare.NBuilder;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    static class TestDataExtensions
    {
        public static TVal Random<TVal>(this IList<TVal> @this) {
            return Pick<TVal>.RandomItemFrom(@this);
        }
    }


    internal class TestData
    {
        public Dog[] Dogs { get; private set; }
        public Person[] People { get; private set; }
        public DogGroomer[] Groomers { get; private set; }
        public Contract[] Contracts { get; private set; }
        
        public TestData() {
            var dogNames = new[] { "Rex", "Gnasher", "Gnipper", "Fido", "Beethoven", "K9", "Yap-Yap", "Prince", "Teddy Pom-Pom" };
            var dogAges = Enumerable.Range(0, 18).ToArray();
            var personNames = new[] { "Geoff", "Guinivere", "Aldridge", "Humphrey", "Charlotte", "Gwendeline", "Rupert", "Colin", "Tamsin", "Philip", "Barbara", "Rod", "Charlotte" };
            var prices = new[] { 5M, 7M, 15M, 20M, 50M };

            People = Builder<Person>.CreateListOfSize(5)
                                        .All()
                                        .Do(p => {
                                            p.Name = personNames.Random();
                                            p.Dogs = new List<Dog>();
                                        }).Build().ToArray();

            Dogs = Builder<Dog>.CreateListOfSize(20)
                                    .All()
                                    .Do(d => {
                                        d.Name = dogNames.Random();
                                        d.Age = dogAges.Random();
                                        d.Owner = People.Random();
                                        d.Owner.Dogs.Add(d);
                                    }).Build().ToArray();

            Groomers = Builder<DogGroomer>.CreateListOfSize(3)
                                    .All()
                                    .Do(g => {
                                        g.Name = personNames.Random();
                                    }).Build().ToArray();

            Contracts = Builder<Contract>.CreateListOfSize(7)
                                    .All()
                                    .Do(c => {
                                        c.Dog = Dogs.Random();
                                        c.Groomer = Groomers.Random();
                                        c.Fee = prices.Random();
                                    }).Build().ToArray();
        }
                
    }

}

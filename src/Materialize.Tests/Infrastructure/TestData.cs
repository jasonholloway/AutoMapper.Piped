using FizzWare.NBuilder;
using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests.Infrastructure
{
    class TestData
    {
        public Dog[] Dogs { get; private set; }
        public Person[] People { get; private set; }
        public DogGroomer[] Groomers { get; private set; }
        public Contract[] Contracts { get; private set; }

        public TestData() {
            Queue<string> qDogNames = new Queue<string>(new[] { "Rex", "Gnasher", "Gnipper", "Fido", "Beethoven", "K9", "Yap-Yap", "Prince", "Teddy Pom-Pom" });
            int[] dogAges = Enumerable.Range(0, 18).ToArray();
            Queue<string> qPersonNames = new Queue<string>(new[] { "Geoff", "Guinivere", "Aldridge", "Humphrey", "Charlotte", "Gwendeline", "Rupert", "Colin" });
            Queue<string> qGroomerNames = new Queue<string>(new[] { "Tamsin", "Philip", "Barbara", "Rod", "Charlotte" });
            decimal[] prices = { 5M, 7M, 15M, 20M, 50M };

            People = Builder<Person>.CreateListOfSize(5)
                                        .All()
                                        .Do(p => {
                                            p.Name = qPersonNames.Dequeue();
                                        }).Build().ToArray();

            Dogs = Builder<Dog>.CreateListOfSize(8)
                                    .All()
                                    .Do(d => {
                                        d.Name = qDogNames.Dequeue();
                                        d.Age = Pick<int>.RandomItemFrom(dogAges);
                                        d.Owner = Pick<Person>.RandomItemFrom(People);
                                    }).Build().ToArray();

            Groomers = Builder<DogGroomer>.CreateListOfSize(3)
                                    .All()
                                    .Do(g => {
                                        g.Name = qGroomerNames.Dequeue();
                                    }).Build().ToArray();

            Contracts = Builder<Contract>.CreateListOfSize(7)
                                    .All()
                                    .Do(c => {
                                        c.Dog = Pick<Dog>.RandomItemFrom(Dogs);
                                        c.Groomer = Pick<DogGroomer>.RandomItemFrom(Groomers);
                                        c.Fee = Pick<decimal>.RandomItemFrom(prices);
                                    }).Build().ToArray();
        }
                
    }

}

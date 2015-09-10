using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Demo
{
    class TestData
    {
        public Rabbit[] Rabbits { get; private set; }
        public RabbitVendor[] Vendors { get; private set; }
        public RabbitBreed[] Breeds { get; private set; }
        public Town[] Towns { get; private set; }
        

        public TestData() {
            var qRabbitNames = new Queue<string>(new[] {
                "Fluffy", "Bunnikins", "Hopper", "Marvin", "Cottontail", "Rupert", "Bunn-Bunn", "Humphrey", "Russell" });

            var qPersonNames = new Queue<string>(new[] {
                "Geoff", "Guinivere", "Aldridge", "Humphrey", "Charlotte", "Gwendeline", "Rupert", "Colin", "Roderick" });

            var qBreedNames = new Queue<string>(new[] {
                "Holland Lop", "Jersey Woolly", "Florida White", "Continental Giant" });

            var qTownNames = new Queue<string>(new[] {
                "Rochdale", "Glossop", "Stalybrisge", "Leek"});
            
            decimal[] prices = {
                1.99M, 5M, 7.49M, 15M, 20M, 50M };


            Breeds = Builder<RabbitBreed>.CreateListOfSize(4)
                                            .All()
                                            .Do(b => {
                                                b.Name = qBreedNames.Dequeue();
                                            }).Build().ToArray();

            Towns = Builder<Town>.CreateListOfSize(4)
                                            .All()
                                            .Do(t => {
                                                t.Name = qTownNames.Dequeue();
                                            }).Build().ToArray();

            Vendors = Builder<RabbitVendor>.CreateListOfSize(9)
                                            .All()
                                            .Do(v => {
                                                v.Name = qPersonNames.Dequeue();
                                                v.Town = Pick<Town>.RandomItemFrom(Towns);
                                                v.RabbitForSale = Builder<Rabbit>.CreateNew()
                                                                                .Do(r => {
                                                                                    r.Name = qRabbitNames.Dequeue();
                                                                                    r.Price = Pick<decimal>.RandomItemFrom(prices);
                                                                                    r.Breed = Pick<RabbitBreed>.RandomItemFrom(Breeds);
                                                                                })
                                                                                .Build();                                                
                                            }).Build().ToArray();

            Rabbits = Vendors.Select(v => v.RabbitForSale)
                                .ToArray();
            
        }

    }




}

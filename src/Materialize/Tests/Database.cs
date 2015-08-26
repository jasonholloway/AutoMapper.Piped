using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materialize.Tests
{

    class Context : DbContext
    {
        public Context() {
            Database.SetInitializer<Context>(new DatabaseInitializer());
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
    }


    class DatabaseInitializer
        : DropCreateDatabaseAlways<Context> // CreateDatabaseIfNotExists<Context>
    {
        string[] _dogNames = { "Rex", "Gnasher", "Gnipper", "Fido", "Beethoven", "K9", "Yap-Yap", "Prince", "Teddy Pom-Pom" };
        int[] _dogAges = Enumerable.Range(0, 18).ToArray();
        string[] _personNames = { "Geoff", "Guinivere", "Aldridge", "Humphrey", "Charlotte", "Gwendeline", "Rupert", "Colin" };
        
        protected override void Seed(Context context) {
            var people = Builder<Person>.CreateListOfSize(5)
                                        .All()
                                        .Do(p => {
                                            p.Name = Pick<string>.RandomItemFrom(_personNames);
                                        }).Build();

            var dogs = Builder<Dog>.CreateListOfSize(8)
                                    .All()
                                    .Do(d => {
                                        d.Name = Pick<string>.RandomItemFrom(_dogNames);
                                        d.Age = Pick<int>.RandomItemFrom(_dogAges);
                                        d.Owner = Pick<Person>.RandomItemFrom(people);
                                    }).Build();

            context.People.AddRange(people);
            context.Dogs.AddRange(dogs);

            base.Seed(context);
        }
    }

}

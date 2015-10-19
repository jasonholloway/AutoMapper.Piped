using Materialize.Tests.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Materialize.Tests.Infrastructure
{

    class Context : DbContext
    {
        static Lazy<DbConnection> _lzConn = new Lazy<DbConnection>(() => Effort.DbConnectionFactory.CreatePersistent("dfg"));

        public Context() : base(_lzConn.Value, false) {
            Database.SetInitializer<Context>(new DatabaseInitializer());
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<DogGroomer> Groomers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
        

    class DatabaseInitializer
        : /*DropCreateDatabaseIfModelChanges<Context>*/  /*DropCreateDatabaseAlways<Context>*/ CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context) {
            var data = new TestData();
                        
            context.People.AddRange(data.People);
            context.Dogs.AddRange(data.Dogs);
            context.Groomers.AddRange(data.Groomers);
            context.Contracts.AddRange(data.Contracts);

            base.Seed(context);
        }
    }

}

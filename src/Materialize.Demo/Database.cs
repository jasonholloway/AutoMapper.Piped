using System.Data.Entity;

namespace Materialize.Demo
{

    class Context : DbContext
    {
        public Context() {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Rabbit> Rabbits { get; set; }
        public DbSet<RabbitVendor> Vendors { get; set; }
    }


    class DatabaseInitializer
        : DropCreateDatabaseAlways<Context> // CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context) {
            var data = new TestData();
                        
            context.Rabbits.AddRange(data.Rabbits);
            context.Vendors.AddRange(data.Vendors);

            base.Seed(context);
        }
    }

}

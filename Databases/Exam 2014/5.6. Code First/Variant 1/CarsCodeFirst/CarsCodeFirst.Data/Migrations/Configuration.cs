namespace CarsCodeFirst.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            ContextKey = "CarsCodeFirst.Data.CarsDbContext";
        }

        protected override void Seed(CarsDbContext context)
        {
            context.Manufacturers.AddOrUpdate(
                m => m.Name,
                new Manufacturer { Name = "Karuca" },
                new Manufacturer { Name = "MoreKaruca" }, 
                new Manufacturer { Name = "FancyKaruc" }
            );

            context.Dealers.AddOrUpdate(
                p => p.Name,
                new Dealer { Name = "Ivan" },
                new Dealer { Name = "Gosho" }, 
                new Dealer { Name = "Pesho" }
            );
        }
    }
}

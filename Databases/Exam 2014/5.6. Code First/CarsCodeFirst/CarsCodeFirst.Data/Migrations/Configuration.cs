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

        protected override void Seed(CarsCodeFirst.Data.CarsDbContext context)
        {

            context.Manufacturers.AddOrUpdate(new Manufacturer
            {
                Name = "Karuca"
            });

            context.Manufacturers.AddOrUpdate(new Manufacturer
            {
                Name = "MoreKaruca"
            });

            context.Manufacturers.AddOrUpdate(new Manufacturer
            {
                Name = "FancyKaruc"
            });

            context.Dealers.AddOrUpdate(
                p => p.Name,
                new Dealer { Name = "Ivan" },
                new Dealer { Name = "Gosho" }, 
                new Dealer { Name = "Pesho" }
            );
        }
    }
}

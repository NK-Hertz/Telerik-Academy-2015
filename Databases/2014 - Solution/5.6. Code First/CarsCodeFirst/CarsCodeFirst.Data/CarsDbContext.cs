namespace CarsCodeFirst.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext()
            : base("Cars")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Dealer> Dealers { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}

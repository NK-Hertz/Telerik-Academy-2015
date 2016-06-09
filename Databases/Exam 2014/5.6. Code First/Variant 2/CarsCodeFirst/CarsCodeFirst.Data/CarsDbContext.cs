namespace CarsCodeFirst.Data
{
    using Models;
    using System.Data.Entity;

    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext()
            : base("CarsSystem")
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Dealer> Dealers { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}

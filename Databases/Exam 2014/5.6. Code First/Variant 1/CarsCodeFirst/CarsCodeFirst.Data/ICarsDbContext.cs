namespace CarsCodeFirst.Data
{
    using System.Data.Entity;
    using Models;

    public interface ICarsDbContext
    {
        IDbSet<Car> Cars { get; set; }
        IDbSet<City> Cities { get; set; }
        IDbSet<Dealer> Dealers { get; set; }
        IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}
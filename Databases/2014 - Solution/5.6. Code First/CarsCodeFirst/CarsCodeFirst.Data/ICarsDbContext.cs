using System.Data.Entity;
using CarsCodeFirst.Models;

namespace CarsCodeFirst.Data
{
    public interface ICarsDbContext
    {
        IDbSet<Car> Cars { get; set; }
        IDbSet<City> Cities { get; set; }
        IDbSet<Dealer> Dealers { get; set; }
        IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}
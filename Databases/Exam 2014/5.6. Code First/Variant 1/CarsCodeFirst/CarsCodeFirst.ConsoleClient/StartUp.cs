namespace CarsCodeFirst.ConsoleClient
{
    using Models;
    using Data;
    using Data.Migrations;
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using CarsCodeFirst.Models;
    public class StartUp
    {
        public const string templatePathForJsonFiles = "Data.Json.Files/data.{0}.json";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
            //var dbContext = new CarsDbContext();
            //using (dbContext)
            //{
            //    Console.WriteLine(dbContext.Cars.Count());
            //}

            // Task 6
            for (int i = 0; i < 5; i++)
            {
                var currentJsonFilePath = string.Format(templatePathForJsonFiles, i);

                ImportData(currentJsonFilePath);

                Console.WriteLine("==================================================");
                Console.WriteLine("Finished: {0}", currentJsonFilePath);
                Console.WriteLine("Clear DB from all entries and then continue!");
                Console.WriteLine("==================================================");
            }
        }

        public static void ImportData(string directory)
        {
            var db = new CarsDbContext();
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Configuration.AutoDetectChangesEnabled = false;

            using (StreamReader reader = new StreamReader(directory))
            {
                var json = reader.ReadToEnd();
                //Console.WriteLine(json);

                var cars = JsonConvert.DeserializeObject<List<CarJson>>(json);

                //StringComparer.OrdinalIgnoreCase in constructor
                //new HashSet<string>
                var dealers = new List<DealerJson>();
                var cities = new HashSet<string>();
                var manufacturers = new HashSet<string>();

                foreach (var car in cars)
                {
                    cities.Add(car.Dealer.City);
                    dealers.Add(car.Dealer);
                    manufacturers.Add(car.Manufacturer);
                }

                foreach (var city in cities)
                {
                    // with 1 dealer in two towns it will make two of the same dealers
                    db.Cities.AddOrUpdate(new City
                    {
                        Name = city,
                        Dealers = dealers.Where(d => d.City == city).Select(d => new Dealer
                        {
                            Name = d.Name
                        }).ToList()
                    });
                }

                db.SaveChanges();

                foreach (var manufacturer in manufacturers)
                {
                    db.Manufacturers.AddOrUpdate(new Manufacturer
                    {
                        Name = manufacturer
                    });
                }

                db.SaveChanges();

                for (var car = 0; car < cars.Count; car++)
                {
                    // slow ?
                    var currentCarDealersName = cars[car].Dealer.Name;
                    var currentDealer = db.Dealers.Where(d => d.Name == currentCarDealersName).First();

                    var currentCarManufacturersName = cars[car].Manufacturer;
                    var currentManufacturer = db.Manufacturers.Where(m => m.Name == currentCarManufacturersName).First();

                    db.Cars.AddOrUpdate(new Car
                    {
                        Year = cars[car].Year,
                        Transmission = cars[car].TransmissionType,
                        Model = cars[car].Model,
                        Price = cars[car].Price,
                        Manufacturer = currentManufacturer,
                        Dealer = currentDealer
                    });

                    if (car % 100 == 0)
                    {
                        db.SaveChanges();
                        db.Dispose();
                        db = new CarsDbContext();
                    }

                    db.SaveChanges();

                    db.Configuration.ValidateOnSaveEnabled = true;
                    db.Configuration.AutoDetectChangesEnabled = true;
                }
            }
        }
    }
}

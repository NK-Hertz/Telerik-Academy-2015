namespace CarsCodeFirst.ConsoleClient
{
    using CarsCodeFirst.Models;
    using Data;
    using Data.Migrations;
    using Models;
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;

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

            ImportData();
        }

        public static void ImportData()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var cars = Directory
                .GetFiles(currentDirectory + "/Data.Json.Files/")
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .SelectMany(str => JsonConvert.DeserializeObject<IEnumerable<CarJson>>(str))
                .ToList();

            var db = new CarsDbContext();
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Configuration.AutoDetectChangesEnabled = false;

            var cities = new HashSet<string>();
            var manufacturers = new HashSet<string>();

            Console.Write("Adding cars");

            var carCount = 0;
            foreach (var car in cars)
            {
                var currentCityName = car.Dealer.City;

                if (!cities.Contains(currentCityName))
                {
                    var currentCity = new City
                    {
                        Name = currentCityName
                    };

                    cities.Add(currentCityName);
                    db.Cities.Add(currentCity);
                    db.SaveChanges();
                }

                var currentDealerName = car.Dealer.Name;
                var currentDealer = new Dealer
                {
                    Name = currentDealerName
                };

                var dbCity = db.Cities.FirstOrDefault(c => c.Name == currentCityName);
                currentDealer.Cities.Add(dbCity);

                var currentManufacturerName = car.Manufacturer;
                if (!manufacturers.Contains(currentManufacturerName))
                {
                    var currentManufacturer = new Manufacturer
                    {
                        Name = currentManufacturerName
                    };

                    manufacturers.Add(currentManufacturerName);
                    db.Manufacturers.Add(currentManufacturer);
                    db.SaveChanges();
                }

                db.SaveChanges();

                var dbManufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.Manufacturer);

                var currentCar = new Car
                {
                    Year = car.Year,
                    Transmission = car.TransmissionType,
                    Model = car.Model,
                    Price = car.Price,
                    Manufacturer = dbManufacturer,
                    Dealer = currentDealer
                };

                db.Cars.Add(currentCar);

                if (carCount % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsDbContext();
                }

                carCount++;
            }
            
            db.SaveChanges();

            db.Configuration.ValidateOnSaveEnabled = true;
            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

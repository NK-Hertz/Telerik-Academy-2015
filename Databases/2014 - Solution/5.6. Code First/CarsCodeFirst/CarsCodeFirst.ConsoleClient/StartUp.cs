namespace CarsCodeFirst.ConsoleClient
{
    using Models;
    using Data;
    using Newtonsoft.Json;
    using System.IO;
    using System.Collections.Generic;
    using System;
    using Newtonsoft.Json.Linq;
    using System.Data.Entity;
    using Data.Migrations;

    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());

            //var dbContext = new CarsDbContext();
            //using (dbContext)
            //{
            //    dbContext.Manufacturers.Add(new Manufacturer
            //    {
            //        Name = "Hello"
            //    });
            //    dbContext.SaveChanges();
            //}

            using (StreamReader reader = new StreamReader("Data.Json.Files\\data.0.json"))
            {
                var json = reader.ReadToEnd();
                Console.WriteLine(json);

                var cars = JsonConvert.DeserializeObject<List<Car>>(json);

				// TO DO:
				// Add the objects to db
                //using (CarsDbContext dbContext = new CarsDbContext())
                //{
                //}
            }
        }
    }
}

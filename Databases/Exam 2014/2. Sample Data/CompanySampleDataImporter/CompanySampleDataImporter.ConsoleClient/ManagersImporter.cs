namespace CompanySampleDataImporter.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;
    using System.Collections.Generic;

    public class ManagersImporter : IImporter
    {
        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) => 
                {
                    var levels = new int[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 };

                    var allEmployeeIds = db.Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var currentPercentage = 0;
                    List<int> previousManagers = null;
                    for (int i = 0; i < levels.Length; i++)
                    {
                        var skip = (int)((currentPercentage * allEmployeeIds.Count) / 100.0);
                        var take = (int)((levels[i] * allEmployeeIds.Count) / 100.0);

                        var currentEmployeeIds = allEmployeeIds.Skip(skip).Take(take).ToList();

                        var employees = db.Employees.Where(e => currentEmployeeIds.Contains(e.Id)).ToList();

                        for (int j = 0; j < employees.Count; j++)
                        {
                            employees[j].ManagerId = previousManagers == null ? null : (int?)previousManagers[RandomGenerator.GetRandomNumber(0, previousManagers.Count - 1)];
                        }

                        tw.Write(".");

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }

                        previousManagers = currentEmployeeIds;
                        currentPercentage += levels[i];
                    }

                    db.SaveChanges(); 
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing managers";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }
    }
}

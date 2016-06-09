namespace CompanySampleDataImporter.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;
    using Data;

    public class ReportsImporter : IImporter
    {
        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    var employeeIds = db.Employees.Select(e => e.Id).ToList();

                    for (int i = 0; i < employeeIds.Count; i++)
                    {
                        var numberOfReports = RandomGenerator.GetRandomNumber(25, 75);

                        for (int j = 0; j < numberOfReports; j++)
                        {
                            db.Reports.Add(new Report
                            {
                                EmployeeId = employeeIds[i],
                                ReportTime = RandomGenerator.GetRandomDate(before: DateTime.Now)
                            });
                        }

                        tw.Write(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();
                    }
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing reports";
            }
        }

        public int Order
        {
            get
            {
                return 5;
            }
        }
    }
}

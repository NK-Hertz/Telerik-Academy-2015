namespace CompanySampleDataImporter.ConsoleClient
{
    using System;
    using System.IO;
    using Data;

    public class DepartmentsImporter : IImporter
    {
        private const int NumberOfDepartments = 10; // 100

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tw) =>
                {
                    for (int i = 0; i < NumberOfDepartments; i++)
                    {
                        db.Departments.Add(new Department
                        {
                            Name = RandomGenerator.GetRandomString(10, 50)
                        });

                        if (i % 10 == 0)
                        {
                            tw.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing departments";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }
    }
}

namespace ExtendingEmployeeTask
{
    using CreateDBContextWithEFDesigner;
    using System;
    using System.Linq;

    public class ExtendingEmployeeTask
    {
        static void Main()
        {
            NorthwindEntities northwind = new NorthwindEntities();
            var nancy = northwind.Employees.FirstOrDefault();
            var nancyExtended = new EmployeeExtended();
            nancyExtended.EmployeeID = nancy.EmployeeID;
            nancyExtended.GetEmployeeTerritories();

            foreach (var ter in nancyExtended.Territories)
            {
                Console.WriteLine("{0} {1} {2}", ter.TerritoryID, ter.TerritoryDescription.Trim(), ter.RegionID);
            } 
        }
    }
}

namespace ExtendingEmployeeTask
{
    using CreateDBContextWithEFDesigner;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeExtended : Employee
    {
        public void GetEmployeeTerritories()
        {
            NorthwindEntities northwind = new NorthwindEntities();
            using (northwind)
            {
                string findEmployeesTerritoriesQuery = string.Format("SELECT t.TerritoryID, t.TerritoryDescription, t.RegionID" +
                                                " FROM Employees e INNER JOIN EmployeeTerritories et" +
                                                " ON e.EmployeeID = et.EmployeeID INNER JOIN Territories t" +
                                                " ON et.TerritoryID = t.TerritoryID WHERE e.EmployeeID = '{0}';",
                                                this.EmployeeID);
                this.Territories = northwind.Database.SqlQuery<Territory>(findEmployeesTerritoriesQuery).ToList();
            }
        }
    }
}

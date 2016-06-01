namespace DAOCustomer
{
    using System;
    using System.Linq;
    using CreateDBContextWithEFDesigner;

    class DAOCustomerTask
    {
        static void Main()
        {
            NorthwindEntities northwind = new NorthwindEntities();
            //Customer alf = new Customer
            //{
            //    CustomerID = "ALFAK",
            //    CompanyName = "Melmac Industries"
            //};
            //CustomerDao.InsertCustomer(alf);
            //CustomerDao.UpdateCustomerContactName(alf.CustomerID, "Alf Tanner");
            //CustomerDao.DeleteCustomer(alf.CustomerID);

            //// 3.Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //var year = DateTime.Parse("1997-01-01");
            //var country = "Canada";
            //CustomerDao.GetAllCustomersWhoOrderedInYearXAndShippedToCountry(year, country);

            //// 4.Implement previous by using native SQL query and executing it through the DbContext
            //var customerSearchQuery = "SELECT c.CustomerID, c.ContactName, o.OrderDate, o.ShipCountry " + 
            //    "FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID WHERE o.ShipCountry = 'Canada' " + 
            //    "AND(o.OrderDate >= '1997' AND o.OrderDate <= '1997-12-31')";
            //var customersWhoOrderedIn1997AndShippedToCanada = 
            //        northwind.Database.SqlQuery<CustomerAndOrder>(customerSearchQuery);

            //foreach (var customer in customersWhoOrderedIn1997AndShippedToCanada)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", customer.CustomerID, customer.ContactName,
            //            customer.OrderDate, customer.ShipCountry);
            //}
            //Console.WriteLine();

            // 5.Write a method that finds all the sales by specified region and period (start / end dates).
            //GetSalesByRegionAndPeriod("SP", DateTime.Parse("1997-05-08"), DateTime.Parse("1998-11-08"));

            // 7.Try to open two different data contexts and perform concurrent changes 
            // on the same records.
            // Q: What will happen at SaveChanges() ?
            // A: It`s using optimistic locking, so no change made in the first DBContext
            // will reflect in the second DBContext, until the application is restarted or 
            // a new DBContext(pointing to the same DB) is created after the change is made
            // Q: How to deal with it ?
            // A: With "using" statement. This way we have one and after we are done with it
            // or open new one it will have the changes.
            NorthwindEntities northwindSecond = new NorthwindEntities();

            var firstEmployeeInNorthwind = northwind.Employees.FirstOrDefault();
            var firstEmployeeInNorthwindSecond = northwindSecond.Employees.FirstOrDefault();

            Console.WriteLine("Before Change: ");
            PrintEmployeeInfo(firstEmployeeInNorthwind);
            PrintEmployeeInfo(firstEmployeeInNorthwindSecond);

            firstEmployeeInNorthwind.FirstName = "Bob Ross";
            firstEmployeeInNorthwind.LastName = "Take over the wheel";

            northwind.SaveChanges();

            Console.WriteLine("After Change: ");
            PrintEmployeeInfo(firstEmployeeInNorthwind);
            PrintEmployeeInfo(firstEmployeeInNorthwindSecond);
        }

        // UNFINISHED
        // 5.Write a method that finds all the sales by specified region and period (start / end dates).
        public static void GetSalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            NorthwindEntities northwind = new NorthwindEntities();
            var salesSatisfiengDate = from order in northwind.Orders
                                      join orderDetail in northwind.Order_Details
                                      on order.OrderID equals orderDetail.OrderID
                                      join product in northwind.Products
                                      on orderDetail.ProductID equals product.ProductID
                                      where order.OrderDate >= startDate && order.OrderDate <= endDate
                                      orderby order.OrderDate
                                      select new
                                      {
                                          EmployeeID = order.EmployeeID,
                                          ProductName = product.ProductName,
                                          OrderDate = order.OrderDate,
                                          //Region = from employee in northwind.Employees
                                          //         join territory in northwind.Territories
                                          //         on employee.
                                      };

            /* Left to join this condition by EmployeeID with salesSatisfiengDate
                SELECT e.EmployeeID, e.FirstName, e.LastName, 
                t.TerritoryDescription, r.RegionDescription
                FROM Employees e 
                INNER JOIN EmployeeTerritories et
                ON e.EmployeeID = et.EmployeeID
                INNER JOIN Territories t
                ON et.TerritoryID = t.TerritoryID
                INNER JOIN Region r
                ON t.RegionID = r.RegionID
            */

            //foreach (var sale in salesSatisfiengDate)
            //{
            //    Console.WriteLine("{0} {1} {2}", sale.EmployeeID, sale.ProductName, sale.OrderDate);
            //}

        }

        public static void PrintEmployeeInfo(Employee employee)
        {
            Console.WriteLine("{0} {1} {2}", employee.EmployeeID, employee.FirstName, employee.LastName);
        }
    }
}

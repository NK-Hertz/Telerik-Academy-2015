namespace DAOCustomer
{
    using System;
    using System.Linq;
    using CreateDBContextWithEFDesigner;

    public class CustomerDao
    {
        // 2.Create a DAO class with static methods which provide functionality
        // for inserting, modifying and deleting customers. 
        public static void InsertCustomer(Customer customer)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            northwindEntities.Customers.Add(customer);
            northwindEntities.SaveChanges();
            Console.WriteLine("Customer inserted!");
        }

        public static void UpdateCustomerContactName(string customerId, string contactName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var customerToModify = GetCustomerById(northwindEntities, customerId);
            customerToModify.ContactName = contactName;
            northwindEntities.SaveChanges();
            Console.WriteLine("Customer updated!");
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var customer = GetCustomerById(northwindEntities, customerId);
            northwindEntities.Customers.Remove(customer);
            northwindEntities.SaveChanges();
            Console.WriteLine("Customer deleted!");
        }

        public static Customer GetCustomerById(NorthwindEntities entities, string customerId)
        {
            var customer = entities.Customers.FirstOrDefault(
                p => p.CustomerID == customerId);
            return customer;
        }

        // 3.Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static void GetAllCustomersWhoOrderedInYearXAndShippedToCountry(DateTime date, string country)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var customers = from customer in northwindEntities.Customers
                            join order in northwindEntities.Orders
                            on customer.CustomerID equals order.CustomerID
                            where order.ShipCountry == country &&
                            order.OrderDate.Value.Year == date.Year
                            select new
                            {
                                CustomerId = customer.CustomerID,
                                ContactName = customer.ContactName,
                                OrderDate = order.OrderDate,
                                ShipCountry = order.ShipCountry
                            };

            foreach (var customer in customers)
            {
                Console.WriteLine("{0} {1} {2} {3}",customer.CustomerId, customer.ContactName,
                    customer.OrderDate, customer.ShipCountry);
            }
        }
    }
}

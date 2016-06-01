using System;

namespace DAOCustomer
{
    public class CustomerAndOrder
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }
    }
}

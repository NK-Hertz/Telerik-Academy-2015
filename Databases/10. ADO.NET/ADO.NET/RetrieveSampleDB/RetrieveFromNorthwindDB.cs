
namespace RetrieveSampleDB
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class RetrieveNumber
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=Admin-PC;Database=Northwind; Integrated Security=true");
            con.Open();

            using (con)
            {
                //Write a program that retrieves from the Northwind sample database in MS SQL Server 
                // the number of rows in the Categories table.
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", con);
                int numberOfRowsInCategories = (int)command.ExecuteScalar();
                Console.WriteLine("Number of rows in categories : {0}", numberOfRowsInCategories);
                Console.WriteLine();

                // Write a program that retrieves the name and description of all
                // categories in the Northwind DB.
                command = new SqlCommand("SELECT CategoryName, Description FROM Categories", con);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string categoryDescription = (string)reader["Description"];

                        Console.WriteLine("{0} : {1}", categoryName, categoryDescription);
                    }
                    Console.WriteLine();
                }

                // Write a program that retrieves from the Northwind database all product
                // categories and the names of the products in each category.
                // Can you do this with a single SQL query (with table join)?
                command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c " 
                        + " INNER JOIN Products p ON p.CategoryID = c.CategoryID " + 
                        " ORDER BY c.CategoryName", con);
                reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        string categoryName = (string)reader["CategoryName"];

                        Console.WriteLine("{0} : {1}", categoryName, productName);
                    }
                    Console.WriteLine();
                }

                //Write a method that adds a new product in the products table in the Northwind database.
                // Use a parameterized SQL command.
                AddProduct(con, 1, 1, "karat", 37.92M, 1500, 500, 0, "Gold", false);
                Console.WriteLine();

                con.Close();
            }
        }

        public static void AddProduct(SqlConnection connection, int supplierID, int categoryID, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, string productName = null, bool discontinued = false)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Products (ProductName, SupplierID," + 
                    " CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel," + 
                    " Discontinued) VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice," + 
                    " @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", connection);

            command.Parameters.AddWithValue("@ProductName", productName);
            command.Parameters.AddWithValue("@SupplierID", supplierID);
            command.Parameters.AddWithValue("@CategoryID", categoryID);
            command.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
            command.Parameters.AddWithValue("@UnitPrice", unitPrice);
            command.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            command.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
            command.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
            command.Parameters.AddWithValue("@Discontinued", discontinued);

            command.ExecuteNonQuery();

            Console.WriteLine("Product inserted!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveImagesFromNorthwind
{
    class RetrieveImagesFromNorthwind
    {
        static void Main(string[] args)
        {
            SqlConnection connecion = new SqlConnection(
                    "Server=Admin-PC;Database=Northwind;Trusted_Connection=True;");
            connecion.Open();

            SqlCommand command = new SqlCommand("SELECT Picture FROM Categories", connecion);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {

                }
            }
        }
    }
}

// Write a program that reads a string from the console and finds 
// all products that contain this string.
// Ensure you handle correctly characters like ', %, ", \ and _.
namespace GetAllProductsByString
{
    using System;
    using System.Data.SqlClient;

    class GetAllProductsByString
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=Admin-PC;Database=Northwind;Integrated Security=true;");
            connection.Open();

            using (connection)
            {
                Console.WriteLine("Enter string to search for: ");
                Console.WriteLine("Example - 'ch%' or 'cha_'");

                string pattern = Console.ReadLine();
                string commandText = string.Format("SELECT * FROM Products WHERE PATINDEX({0}, ProductName) > 0", pattern).ToString();
                //Console.WriteLine(commandText);

                SqlCommand command = new SqlCommand(commandText);
                command.Connection = connection;
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var product = (string)reader["ProductName"];
                        Console.WriteLine(product);
                    }
                }
            }

            connection.Close();
        }
    }
}

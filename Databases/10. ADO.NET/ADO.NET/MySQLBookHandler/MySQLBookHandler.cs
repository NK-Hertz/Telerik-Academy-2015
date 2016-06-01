// In order this to work you need a database to work on. I`ve made a schema inside this project`s folder 
// which by using MySQL Forward Engineering will help on this matter.  

namespace MySQLBookHandler
{
    using MySql.Data.MySqlClient;
    using System;

    class MySQLBookHandler
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=davaburn;");
            connection.Open();
            Console.WriteLine("Successfully connected to MySQL");

            using (connection)
            {
                ListAllBooks(connection);
                Console.WriteLine();
                AddBook("The Hobbit", DateTime.Parse("1937-09-21"), "13a5sda13", 0, connection);
                AddBook("The Lord of the Rings", DateTime.Now, "apsdajod2", 0, connection);
                AddBook("The Old Man and The Sea", DateTime.Parse("1952-01-01"), "464a5dsa6", 0, connection);
                Console.WriteLine();
                ListAllBooks(connection);
                FindBookByName("Idiot", connection);
            }

            connection.Close();
        }

        public static void ListAllBooks(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM books", connection);
            MySqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var currentBook = reader["Title"];
                    Console.WriteLine(currentBook);
                }
            }
        }

        // use zero for authorId if you don`t want to enter or the desired one is not present
        public static void AddBook(string title, DateTime publishDate, string ISBN, int authorId, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO books(Title, PublishDate, ISBN, AuthorsId)" +
                    " VALUES (@title, @publishDate, @isbn, @authorId)", connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@publishDate", publishDate);
            command.Parameters.AddWithValue("@isbn", ISBN);

            if (authorId != 0)
            {
                command.Parameters.AddWithValue("@authorId", authorId);
            }
            else
            {
                // DBNUll.Value or 0
                command.Parameters.AddWithValue("@authorId", DBNull.Value);
            }

            command.ExecuteNonQuery();
            Console.WriteLine("Book inserted!");
        }

        public static void FindBookByName(string name, MySqlConnection connection)
        {
            string commandText = string.Format("SELECT * FROM books b INNER JOIN authors a ON b.AuthorsId = a.Id WHERE b.Title = '{0}'", name);
            MySqlCommand command = new MySqlCommand(commandText, connection);

            MySqlDataReader reader = command.ExecuteReader();
            using (command)
            {
                while (reader.Read())
                {
                    var title = reader["Title"];
                    var publishDate = reader["PublishDate"];
                    var isbn = reader["ISBN"];
                    var author = reader["Name"];
                    Console.WriteLine("{0} {1} {2} {3}", author, title, publishDate, isbn);
                }
            }
        }
    }
}

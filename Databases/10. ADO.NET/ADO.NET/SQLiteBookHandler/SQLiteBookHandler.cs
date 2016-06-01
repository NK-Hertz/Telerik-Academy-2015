namespace SQLiteBookHandler
{
    using System;
    using System.Data.SQLite;

    class SQLiteBookHandler
    {
        static void Main(string[] args)
        {

            SQLiteConnection.CreateFile("Library.sqlite");
            SQLiteConnection connection = new SQLiteConnection(
                "Data Source=Library.sqlite;Version=3;");
            connection.Open();
            Console.WriteLine("Connected successfully!");
            string createAuthorsTable = "CREATE TABLE Authors (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name NVARCHAR(150))";
            SQLiteCommand command = new SQLiteCommand(createAuthorsTable, connection);
            command.ExecuteNonQuery();

            string insertAuthors = "INSERT INTO Authors(Name) VALUES ('Tolkien'), " +
                " ('Hemingway'), ('Bukawski')";
            command = new SQLiteCommand(insertAuthors, connection);
            command.ExecuteNonQuery();

            string createBooksTable = "CREATE TABLE Books(Id INTEGER PRIMARY KEY AUTOINCREMENT, Title NVARCHAR(100) NOT NULL, " +
                "PublishDate DATE, ISBN VARCHAR(45) UNIQUE NOT NULL, AuthorId INTEGER, " +
                "FOREIGN KEY(AuthorId) REFERENCES Authors(rowid))";
            command = new SQLiteCommand(createBooksTable, connection);
            command.ExecuteNonQuery();

            ListAllBooks(connection);
            Console.WriteLine();

            AddBook("The Hobbit", DateTime.Now, "as56d6asd+56", 1, connection);
            AddBook("A Clockwork Orange", DateTime.Now, "d3as4d5a+56", 0, connection);
            AddBook("The Old Man and the Sea", DateTime.Now, "as5da6sda", 2, connection);
            Console.WriteLine();

            ListAllBooks(connection);
            Console.WriteLine();

            FindBookByName("The Hobbit", connection);

            connection.Close();
        }

        public static void ListAllBooks(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var id = reader["Id"];
                    var title = reader["Title"];
                    var publishDate = reader["PublishDate"];
                    var isbn = reader["ISBN"];
                    Console.WriteLine("{0} {1} {2} {3}", id, title, publishDate, isbn);
                }
            }
        }

        // Use zero for authorId if you don`t want to enter or the desired one is not present
        public static void AddBook(string title, DateTime publishDate, string isbn, int authorId, SQLiteConnection connection)
        {
            string addBookQuery = "INSERT INTO books(Title, PublishDate, ISBN, AuthorId)" +
                    " VALUES (@title, @publishDate, @isbn, @authorId)";
            SQLiteCommand command = new SQLiteCommand(addBookQuery, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@publishDate", publishDate);
            command.Parameters.AddWithValue("@isbn", isbn);

            if (authorId != 0)
            {
                command.Parameters.AddWithValue("@authorId", authorId);
            }
            else
            {
                command.Parameters.AddWithValue("@authorId", DBNull.Value);
            }

            command.ExecuteNonQuery();
            Console.WriteLine("Book inserted!");
        }

        public static void FindBookByName(string name, SQLiteConnection connection)
        {
            string searchQuery = string.Format("SELECT * FROM Books WHERE Title = '{0}'", name);
            SQLiteCommand command = new SQLiteCommand(searchQuery, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var title = reader["Title"];
                    var publishDate = reader["PublishDate"];
                    var isbn = reader["ISBN"];
                    Console.WriteLine("{0} {1} {2}", title, publishDate, isbn);
                }
            }
        }
    }
}

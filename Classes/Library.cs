using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Library
    {
        public bool IsLogged { get; set; }
        public User UserLogged { get; set; }

        public List<User> Users { get; set; }

        public List<Book> Books { get; set; }

        public Library() { }

        public void UnloggedPage()
        {
            Console.WriteLine($"\n*** ONLINE LIBRARY ***");
            Console.WriteLine($"1. Register");
            Console.WriteLine($"2. Login");
            Console.WriteLine($"3. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch(input) {
                case 1:
                    this.Register();
                    break;
                case 2:
                    this.Login();
                    break;
                case 3:
                    return;
                    break;
            }
        }

        SqlConnection connectionSql = new SqlConnection("Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True");
        private void Register()
        {
            Console.WriteLine($"\n* REGISTER *\n");
            Console.WriteLine($"Insert your data:");


            Console.Write($"Surname: ");
            string surname = Console.ReadLine();
            Console.Write($"Name: ");
            string name = Console.ReadLine();
            Console.Write($"Email: ");
            string email = Console.ReadLine();
            Console.Write($"Password: ");
            string password = Console.ReadLine();
   

            try
            {
                connectionSql.Open();
                string query = "INSERT INTO [users] (surname, name, email, password) VALUES (@Surname, @Name, @Email, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, connectionSql))
                {
                    cmd.Parameters.Add(new SqlParameter("@Surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@Name", name));
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", password));

                    int affectedRows = cmd.ExecuteNonQuery(); // per eseguire l'insert
                    Console.WriteLine(affectedRows);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            connectionSql.Close();


            this.Login();
        }

        private void Login()
        {
            Console.WriteLine($"\n* LOGIN *\n");
            Console.WriteLine($"Insert your data:");

            Console.Write($"Email: ");
            string email = Console.ReadLine();
            Console.Write($"Password: ");
            string password = Console.ReadLine();

            try
            {
                connectionSql.Open();
                string query = "SELECT TOP 1 * FROM [users] WHERE email=@Email AND password=@password";
                using (SqlCommand cmd = new SqlCommand(query, connectionSql))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(email == reader.GetString(2) && password == reader.GetString(3)){
                        Console.WriteLine("Welcome, you are logged in");
                        UserLogged = new User(email, password);
                        this.LoggedPage();
                    }
                    else
                    {
                        Console.WriteLine("Failed login");
                        this.UnloggedPage();
                    }
                }
            }catch(Exception ex)
            {
                ex.ToString();
            }

            connectionSql.Close();


        }

        private void LoggedPage()
        {
            Console.WriteLine($"\n*** ONLINE LIBRARY ***");
            Console.WriteLine($"1. Search book");
            Console.WriteLine($"2. Search DVD");
            Console.WriteLine($"3. View rentals");
            Console.WriteLine($"4. Logout");
            Console.WriteLine($"5. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    this.SearchBook();
                    break;
                case 2:
                    //this.SearchDvd();
                    break;
                case 3:
                    //this.ViewRentals();
                    break;
                case 4:
                    this.Logout();
                    break;
                case 5:
                    return;
                    break;
            }
        }

        private void Logout()
        {
            IsLogged = false;
            UserLogged = null;

            this.UnloggedPage();
        }

        private void SearchBook()
        {
            Console.WriteLine($"\n* SEARCH BOOK *\n");
            Console.WriteLine($"1. Search by ISBN");
            Console.WriteLine($"2. Search by title");
            Console.WriteLine($"3. Back");
            Console.WriteLine($"4. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    //this.SearchBookByIsbn();
                    break;
                case 2:
                    this.SearchBookByTitle();
                    break;
                case 3:
                    this.LoggedPage();
                    break;
                case 4:
                    return;
                    break;
            }
        }


        private void SearchBookByTitle()
        {
            Console.WriteLine($"\n* SEARCH BOOK *\n");
            Console.Write($"Insert title: ");
            string title = Console.ReadLine();

            bool foundBook = false;

            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    foundBook = true;
                    this.BookInfo(book);
                }
            }

            if (!foundBook)
            {
                Console.WriteLine("\nBook not found.");
                this.SearchBook();
            }
        }

        private void BookInfo(Book book)
        {
            Console.WriteLine($"\n* BOOK MENU *\n");
            Console.WriteLine($"1. View info");
            Console.WriteLine($"2. Borrow book");
            Console.WriteLine($"3. Return book");
            Console.WriteLine($"4. Back");
            Console.WriteLine($"5. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    //book.printInfo();
                    Console.WriteLine();
                    this.BookInfo(book);
                    break;
                case 2:
                    //this.BorrowBook(book);
                    break;
                case 3:
                    //this.ReturnBook(book);
                    break;
                case 4:
                    this.SearchBook();
                    break;
                case 5:
                    return;
                    break;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyLibraryMVC.Models
{
    public class BooksController : ApiController
    {
        
        List<Books> book = new List<Books>(); 

        public BooksController()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoLibrary"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText =
                  @"select b.Id, b.Name, c.name [Category], a.name [Author]
                    from book b 
                    left join author a on b.author = a.id
                    left join category c on b.category = c.id";

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

                while (reader.Read())
                {
                    Books b = new Books();
                    b.Id = Convert.ToInt32(reader["Id"]);
                    b.Name = reader["Name"].ToString();
                    b.Category = reader["Category"].ToString();
                    b.Author = reader["Author"].ToString();

                    book.Add(b);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }  


        public IEnumerable<Books> GetAllBooks()
        {
            return book;
        }

        public IEnumerable<Books> GetBookByCategory(string id)
        {
            return book.Where(
                (p) => string.Equals(p.Category, id, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Books> GetBookByAuthor(string id)
        {
            return book.Where(
                (p) => string.Equals(p.Author, id, StringComparison.OrdinalIgnoreCase));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BookishConnection"].ConnectionString);
            string sqlString = "SELECT * from tblTitle";
            var titles = (List<BookTitle>) db.Query<BookTitle>(sqlString);

            foreach (var title in titles)
            {
                Console.WriteLine(title.Author);
                Console.WriteLine(title.TitleId);
                Console.WriteLine(title.Isbn);
                Console.WriteLine(title.Title);
            }

            Console.ReadLine();
        }
    }
}

using DBFirst.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Users.ToList().ForEach(u => Console.WriteLine(u.Username+" "+u.DisplayName));
            }
        }
    }
}

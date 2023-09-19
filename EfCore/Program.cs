using EfCore.Models;
using System;

namespace EfCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDbContext();
            var author = new Author
            {
                FirstName = "Ahmed",
                LastName = "Attia"
            };

            _context.Authors.Add(author);
            _context.SaveChanges();


        }
    }
}

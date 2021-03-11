using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BamazonDbContext _context;
        //constructor
        public EFBooksRepository (BamazonDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books; //context allows you access to connect it. Connection string tells you how to connect to it
    }
}
//The repository implementation just maps the Books property defined by the IBooksRepository interface onto the Books property defined by the BamazonDbContext class. 
//The Books property in the context class returns a DbSet<Book> object, which implements the IQueryable<T> interface and makes it easy to implement the repository interface when using Entity Framework Core.
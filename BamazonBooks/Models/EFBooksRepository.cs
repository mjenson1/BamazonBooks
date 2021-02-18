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
        public IQueryable<Book> Books => _context.Books;
    }
}

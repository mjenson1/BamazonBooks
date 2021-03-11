using Microsoft.EntityFrameworkCore; //this was added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models
{
    public class BamazonDbContext : DbContext //BamazonDbContext inherits from a DbContext file
    {
        public BamazonDbContext (DbContextOptions<BamazonDbContext> options) : base (options) //options class. Used to update database
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
//provides access to the database through a context class
//the DbContext base class provides access to the Entity Framework Core's underlying functionality and the "Books" property  will provide
//access to the Books objects in the database. The BamazonDbContext class is derived from the DbContext and adds the properties that will be used to read and write the application's data
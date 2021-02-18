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

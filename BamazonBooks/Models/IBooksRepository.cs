using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; } //setting up a template to inherit from that will interact with the implementation class
    }
}

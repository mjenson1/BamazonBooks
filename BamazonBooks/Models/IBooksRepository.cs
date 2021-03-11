using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; } //setting up a template to inherit from that will interact with the implementation class
        //This interface uses IQueryable<T> to allow a caller to obtain a sequence of Product objects. The IQueryable<T> interface is derived from the more familiar IEnumerable<T> interface and represents a collection of objects that can be queried, such as those managed by a database.
    }
}
//A class that depends on the IBooksRepository interface can obtain Books objects without needing to know the details of how they are stored or how the implementation class will deliver them
//the repository is useful b/c it can reduce duplicatoin and ensure that operations on the database are performed consistently.
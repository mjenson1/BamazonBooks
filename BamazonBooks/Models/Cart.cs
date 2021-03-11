using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book book, int qty)
        {
            CartLine line = Lines //go out to the lines object which is a list of cartlines
                .Where(p => p.Book.BookId == book.BookId) //where the projectId exists in the list and see if it matches the item passed.
                .FirstOrDefault();

            if (line == null) // if it didn't find it, add it
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else //otherwise update the quantity
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(l => l.Book.BookId == book.BookId);

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity); //Calculate the total amount based on the price of the book and the quantity. 

        public virtual void Clear() => Lines.Clear();
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; } // book is an instance of project
            public int Quantity { get; set; }
        }
    }
}

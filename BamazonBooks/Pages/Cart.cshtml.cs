using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BamazonBooks.Infrastructure;
using BamazonBooks.Models;


namespace BamazonBooks.Pages
{
    public class CartModel : PageModel
    {
        private IBooksRepository repository;

        public CartModel (IBooksRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Constructor
        //public DonateModel (IBooksRepository repo)
        //{
        //    repository = repo;
        //}

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //if null set to "/"
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); // creates new cart if not there
        }

        public IActionResult OnPost(long bookId, string returnUrl) //based on the info passed, select the correct info
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1); //only allow them to add one item to the cart at a time

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

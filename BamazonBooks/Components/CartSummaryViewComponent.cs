using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BamazonBooks.Models;

namespace BamazonBooks.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent (Cart cartService) //receives the cart object as constructor argument
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart); 
        }
    }
}
//This view component is able to take advantage of the service that I created earlier in the chapter to receive a Cart object as a constructor argument. 
//The result is a simple view component class that passes on the Cart to the View method to generate the fragment of HTML that will be included in the layout
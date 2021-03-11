using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BamazonBooks.Infrastructure;

namespace BamazonBooks.Models
{
    public class SessionCart : Cart //session cart implements cart
    {
        public static Cart GetCart(IServiceProvider services) //now the cart will operate independently as we move all of the stuff here
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()? //convert stuff to Json, 
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") //getting json from the session cart so razor doesn't have to mess with it 
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Book book, int qty) //add item to the cart
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Book book) //remove item from the cart
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}

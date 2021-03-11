using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BamazonBooks.Models;

namespace BamazonBooks.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBooksRepository repository;

        public NavigationMenuViewComponent (IBooksRepository r) //The constructor defined in Listing 8-8 defines an IStoreRepository parameter.
            //When ASP.NET Core needs to create an instance of the view component class, it will note the need to provide a value for this parameter and inspect the configuration in the Startup class to determine which implementation object should be used
        {
            repository = r;
        }
        public IViewComponentResult Invoke() //The view component’s Invoke method is called when the component is used in a Razor view, and the result of the Invoke method is inserted into the HTML sent to the browser.
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"]; //ViewBag allows unstructured data to be passed to aview alongside the view model object. 
            
            return View(repository.Books //returning a view with this data set so we build a view to go with it
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

//The ViewComponent base class is no exception and provides access to context objects through a set of properties. One of the properties is called RouteData, which provides information about how the request URL was handled by the routing system.

//Inside the Invoke method, I have dynamically assigned a SelectedCategory property to the ViewBag object and set its value to be the current category, which is obtained through the context object returned by the RouteData property. 
//The ViewBag is a dynamic object that allows me to define new properties simply by assigning values to them.

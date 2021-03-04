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

        public NavigationMenuViewComponent (IBooksRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            
            return View(repository.Books //returning a view with this data set so we build a view to go with it
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

using BamazonBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BamazonBooks.Models.ViewModels;

namespace BamazonBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBooksRepository _repository;

        public int PageSize = 5; //products per page
        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1) //uses these default parameters if none are passed
        {
            return View(new BookListViewModel //the view method is inherited from the Controller base class. Pass a BookListViewModel object as the model data to the view
            {
                Books = _repository.Books //passing the books from the database
                    .Where(b => category == null || b.Category == category) // if category is null, or b type is the category, we'll get the right data 
                    .OrderBy(page => page.BookId) //to set up pages and display content based on the content 
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() : //change this to remove xtra pages
                        _repository.Books.Where(x => x.Category == category).Count()  //f a category has been selected, I return the number of items in that category; if not, I return the total number of products
                },
                CurrentCategory = category
            }) ; ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

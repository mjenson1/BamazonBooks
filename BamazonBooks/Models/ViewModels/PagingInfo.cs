using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models.ViewModels
{
    public class PagingInfo //used to customize info passed to the view
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) (Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
//this class is used to pass data between a controller and a view
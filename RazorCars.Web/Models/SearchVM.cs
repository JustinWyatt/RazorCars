using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class SearchVM
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public string Class { get; set; }
        public string PriceRange { get; set; }
        public string Color { get; set; }
    }
}
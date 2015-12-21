using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class RentalHistoryVM
    {
        public DateTime RentalDate { get; set;}
        public DateTime ReturnDate { get; set;}
        public int TotalSupply { get; set; }
        public int AvailableForRent { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LocationName { get; set; }
       
    }
}
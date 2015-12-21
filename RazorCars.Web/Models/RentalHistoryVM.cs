using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class RentalHistoryVM
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set;}
        public DateTime? ReturnDate { get; set;}
               
    }

}
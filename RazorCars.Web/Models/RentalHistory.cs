using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class RentalHistory
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Inventory Inventory { get; set; }
    }
}
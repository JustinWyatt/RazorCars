using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<RentalHistory> Histories { get; set; }
    }
}
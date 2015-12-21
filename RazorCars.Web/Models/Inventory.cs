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
        public CarType CarType { get; set; }
        public Location Location { get; set; }
    }
}
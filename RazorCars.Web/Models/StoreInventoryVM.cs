using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class StoreInventoryVM
    {
        public int InventoryId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Avaiable { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set;}

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
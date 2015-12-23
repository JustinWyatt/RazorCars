using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class InventoryVM
    {
        public InventoryVM()
        {
            Histories = new List<RentalHistoryVM>();
        }
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set;}
        public int TotalStock { get; set; }
        public int AvailableStock { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public ICollection<RentalHistoryVM> Histories { get; set; }
    }
}
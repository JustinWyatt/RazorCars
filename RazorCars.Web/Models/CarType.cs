using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class CarType
    {
        public int Id { get; set; }
        public string Make { get; set; }    
        public string Model { get; set; }
        public int Year { get; set; }
        public string Photo { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Description { get; set; }
    }
}
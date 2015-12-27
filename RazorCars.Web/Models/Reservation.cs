using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public ReservationLocation Location { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Return { get; set; }
        public int Age { get; set; }
        public Guid Confirmation { get; set; }
    }
}
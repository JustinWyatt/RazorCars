namespace RazorCars.Web.Models
{
    public class ReservationLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public int PhoneNumber { get; set; }
        public string ContactPerson { get; set; }

    }
}
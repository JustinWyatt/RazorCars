namespace RazorCars.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RentalHistory
    {
        public int Id { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? Inventory_Id { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}

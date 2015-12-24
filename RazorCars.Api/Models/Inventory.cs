namespace RazorCars.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            RentalHistories = new HashSet<RentalHistory>();
        }

        public int Id { get; set; }

        public int Stock { get; set; }

        public int? CarType_Id { get; set; }

        public int? Location_Id { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentalHistory> RentalHistories { get; set; }
    }
}

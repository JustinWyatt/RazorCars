namespace RazorCars.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int? CarType_Id { get; set; }

        public virtual CarType CarType { get; set; }
    }
}

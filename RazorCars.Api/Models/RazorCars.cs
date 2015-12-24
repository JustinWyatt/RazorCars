namespace RazorCars.Api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RazorCars : DbContext
    {
        public RazorCars()
            //: base("name=RazorCars")
            : base("data source = (LocalDb)\\MSSQLLocalDB; initial catalog = aspnet - RazorCars.Web - 20151221110632; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<RentalHistory> RentalHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.CarType)
                .HasForeignKey(e => e.CarType_Id);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.CarType)
                .HasForeignKey(e => e.CarType_Id);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.RentalHistories)
                .WithOptional(e => e.Inventory)
                .HasForeignKey(e => e.Inventory_Id);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.AspNetUsers)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.Location_Id);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.Location_Id);
        }
    }
}

namespace RazorCars.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUp = c.DateTime(nullable: false),
                        Return = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Confirmation = c.Guid(nullable: false),
                        Location_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReservationLocations", t => t.Location_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ReservationLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Postal = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "Location_Id", "dbo.ReservationLocations");
            DropIndex("dbo.Reservations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reservations", new[] { "Location_Id" });
            DropTable("dbo.ReservationLocations");
            DropTable("dbo.Reservations");
        }
    }
}

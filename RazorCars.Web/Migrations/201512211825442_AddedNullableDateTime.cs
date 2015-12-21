namespace RazorCars.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RentalHistories", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentalHistories", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}

namespace RazorCars.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarTypes", "Photo", c => c.String());
            AddColumn("dbo.CarTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarTypes", "Description");
            DropColumn("dbo.CarTypes", "Photo");
        }
    }
}

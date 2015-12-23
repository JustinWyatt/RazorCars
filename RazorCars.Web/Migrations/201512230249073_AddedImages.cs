namespace RazorCars.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        CarType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarTypes", t => t.CarType_Id)
                .Index(t => t.CarType_Id);
            
            DropColumn("dbo.CarTypes", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarTypes", "Photo", c => c.String());
            DropForeignKey("dbo.Images", "CarType_Id", "dbo.CarTypes");
            DropIndex("dbo.Images", new[] { "CarType_Id" });
            DropTable("dbo.Images");
        }
    }
}

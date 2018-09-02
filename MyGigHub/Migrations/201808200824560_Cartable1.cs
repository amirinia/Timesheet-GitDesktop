namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cartable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        History = c.String(),
                        Mypriority = c.Int(nullable: false),
                        OwneruserId = c.Int(nullable: false),
                        ReceiveruserId = c.Int(nullable: false),
                        Name = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropTable("dbo.TimesheetFormViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimesheetFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(nullable: false),
                        Name = c.String(),
                        IP = c.String(),
                        TimeStart = c.String(),
                        TimeEnd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Cartables", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cartables", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Cartables");
        }
    }
}

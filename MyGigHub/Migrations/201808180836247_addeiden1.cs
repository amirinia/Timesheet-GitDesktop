namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeiden1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Timesheets", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Timesheets", new[] { "ArtistId" });
            RenameColumn(table: "dbo.Timesheets", name: "ArtistId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Timesheets", "UserId", c => c.String());
            AlterColumn("dbo.Timesheets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Timesheets", "ApplicationUser_Id");
            AddForeignKey("dbo.Timesheets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timesheets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Timesheets", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Timesheets", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Timesheets", "UserId");
            RenameColumn(table: "dbo.Timesheets", name: "ApplicationUser_Id", newName: "ArtistId");
            CreateIndex("dbo.Timesheets", "ArtistId");
            AddForeignKey("dbo.Timesheets", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

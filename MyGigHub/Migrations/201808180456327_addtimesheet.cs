namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtimesheet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Timesheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        StartDay = c.DateTime(nullable: false),
                        EndDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timesheets", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Timesheets", new[] { "ArtistId" });
            DropTable("dbo.Timesheets");
        }
    }
}

namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addViewModels : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimesheetFormViewModels");
        }
    }
}

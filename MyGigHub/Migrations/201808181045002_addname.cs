namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timesheets", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timesheets", "Name");
        }
    }
}

namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timesheets", "IP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timesheets", "IP");
        }
    }
}

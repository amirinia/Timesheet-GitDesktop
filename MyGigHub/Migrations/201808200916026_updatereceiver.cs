namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatereceiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cartables", "Receiveruser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cartables", "Receiveruser_Id");
            AddForeignKey("dbo.Cartables", "Receiveruser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Cartables", "OwneruserId");
            DropColumn("dbo.Cartables", "ReceiveruserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cartables", "ReceiveruserId", c => c.Int(nullable: false));
            AddColumn("dbo.Cartables", "OwneruserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cartables", "Receiveruser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cartables", new[] { "Receiveruser_Id" });
            DropColumn("dbo.Cartables", "Receiveruser_Id");
        }
    }
}

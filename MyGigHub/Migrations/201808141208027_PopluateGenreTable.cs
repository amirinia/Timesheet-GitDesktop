namespace MyGigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopluateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Id, Name) Values(1, 'Jazz')");
            Sql("Insert INTO Genres (Id, Name) Values(2, 'Rock')");
            Sql("Insert INTO Genres (Id, Name) Values(3, 'Rock')");
            Sql("Insert INTO Genres (Id, Name) Values(4, 'Country')");
        }
        
        public override void Down()
        {
        }
    }
}

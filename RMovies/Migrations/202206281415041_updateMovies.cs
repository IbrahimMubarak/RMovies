namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genre", c => c.String());
            AddColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "releseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "numberinStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "numberinStock");
            DropColumn("dbo.Movies", "releseDate");
            DropColumn("dbo.Movies", "dateAdded");
            DropColumn("dbo.Movies", "genre");
        }
    }
}

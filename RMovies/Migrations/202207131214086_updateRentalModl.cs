namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRentalModl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "movie_id" });
            CreateIndex("dbo.Rentals", "Movie_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "Movie_id" });
            CreateIndex("dbo.Rentals", "movie_id");
        }
    }
}

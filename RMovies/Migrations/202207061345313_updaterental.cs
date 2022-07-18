namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updaterental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Customer_id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "movie_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_id");
            CreateIndex("dbo.Rentals", "movie_id");
            AddForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers", "id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "movie_id", "dbo.Movies", "id", cascadeDelete: true);
            DropColumn("dbo.Rentals", "Customer");
            DropColumn("dbo.Rentals", "movie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "movie", c => c.String(nullable: false));
            AddColumn("dbo.Rentals", "Customer", c => c.String(nullable: false));
            DropForeignKey("dbo.Rentals", "movie_id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movie_id" });
            DropIndex("dbo.Rentals", new[] { "Customer_id" });
            DropColumn("dbo.Rentals", "movie_id");
            DropColumn("dbo.Rentals", "Customer_id");
        }
    }
}

namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "genre", c => c.String());
            AlterColumn("dbo.Movies", "name", c => c.String());
        }
    }
}

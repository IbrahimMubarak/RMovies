namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numberAvilable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "numberAvilable", c => c.Int(nullable: false));
            Sql("update Movies set numberAvilable=numberinStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "numberAvilable");
        }
    }
}

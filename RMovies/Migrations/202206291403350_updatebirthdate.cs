namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebirthdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthday", c => c.DateTime());
        }
    }
}

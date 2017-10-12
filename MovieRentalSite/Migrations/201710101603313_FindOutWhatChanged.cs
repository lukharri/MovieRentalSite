namespace MovieRentalSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FindOutWhatChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateReleased", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateReleased", c => c.DateTime());
        }
    }
}

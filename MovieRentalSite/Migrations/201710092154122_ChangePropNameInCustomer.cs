namespace MovieRentalSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropNameInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewLetter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}

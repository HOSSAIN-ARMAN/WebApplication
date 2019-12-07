namespace Jespar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "SupplierName", c => c.String());
            AddColumn("dbo.Suppliers", "PersonContact", c => c.String());
            DropColumn("dbo.Suppliers", "LoyaltyPoint");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "LoyaltyPoint", c => c.String());
            DropColumn("dbo.Suppliers", "PersonContact");
            DropColumn("dbo.Purchases", "SupplierName");
        }
    }
}

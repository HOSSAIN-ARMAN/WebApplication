namespace Jespar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productCodeColumAddedtoPurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ProductCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ProductCode");
        }
    }
}

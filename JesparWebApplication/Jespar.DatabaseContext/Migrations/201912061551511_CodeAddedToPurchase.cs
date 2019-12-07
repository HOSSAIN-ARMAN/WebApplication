namespace Jespar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeAddedToPurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Code");
        }
    }
}

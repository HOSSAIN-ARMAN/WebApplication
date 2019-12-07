namespace Jespar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updataPurchaseCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "Code", c => c.String());
        }
    }
}

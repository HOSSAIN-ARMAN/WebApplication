namespace Jespar.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        InvoiceNo = c.String(),
                        ManufractureDate = c.String(),
                        ExoireDate = c.String(),
                        Remarks = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitePrice = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        Mrp = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropTable("dbo.Purchases");
        }
    }
}

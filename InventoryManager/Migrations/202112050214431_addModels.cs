namespace InventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinLots",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        BinNumber = c.String(nullable: false, maxLength: 128),
                        LotNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bins", t => t.BinNumber, cascadeDelete: true)
                .ForeignKey("dbo.Lots", t => t.LotNumber, cascadeDelete: true)
                .Index(t => t.BinNumber)
                .Index(t => t.LotNumber);
            
            CreateTable(
                "dbo.Bins",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
            CreateTable(
                "dbo.Lots",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        ProductSku = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        ReceivedAt = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Products", t => t.ProductSku, cascadeDelete: true)
                .Index(t => t.ProductSku);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Sku = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Model = c.String(),
                        Color = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Sku);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductSku = c.String(nullable: false, maxLength: 128),
                        QuantityAvailable = c.Int(nullable: false),
                        QuantityAllocated = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductSku, cascadeDelete: true)
                .Index(t => t.ProductSku);
            
            CreateTable(
                "dbo.InventoryTransactions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        BinLotID = c.Guid(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BinLots", t => t.BinLotID, cascadeDelete: true)
                .Index(t => t.BinLotID);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductSku = c.String(nullable: false, maxLength: 128),
                        Details = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductSku, cascadeDelete: true)
                .Index(t => t.ProductSku);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ProductSku = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(nullable: false),
                        ServerFileName = c.String(nullable: false),
                        FileType = c.String(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductSku, cascadeDelete: true)
                .Index(t => t.ProductSku);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductSku", "dbo.Products");
            DropForeignKey("dbo.ProductDetails", "ProductSku", "dbo.Products");
            DropForeignKey("dbo.InventoryTransactions", "BinLotID", "dbo.BinLots");
            DropForeignKey("dbo.Inventories", "ProductSku", "dbo.Products");
            DropForeignKey("dbo.BinLots", "LotNumber", "dbo.Lots");
            DropForeignKey("dbo.Lots", "ProductSku", "dbo.Products");
            DropForeignKey("dbo.BinLots", "BinNumber", "dbo.Bins");
            DropIndex("dbo.ProductImages", new[] { "ProductSku" });
            DropIndex("dbo.ProductDetails", new[] { "ProductSku" });
            DropIndex("dbo.InventoryTransactions", new[] { "BinLotID" });
            DropIndex("dbo.Inventories", new[] { "ProductSku" });
            DropIndex("dbo.Lots", new[] { "ProductSku" });
            DropIndex("dbo.BinLots", new[] { "LotNumber" });
            DropIndex("dbo.BinLots", new[] { "BinNumber" });
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.InventoryTransactions");
            DropTable("dbo.Inventories");
            DropTable("dbo.Products");
            DropTable("dbo.Lots");
            DropTable("dbo.Bins");
            DropTable("dbo.BinLots");
        }
    }
}

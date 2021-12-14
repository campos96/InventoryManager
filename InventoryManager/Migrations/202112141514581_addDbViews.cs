namespace InventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDbViews : DbMigration
    {
        //this migration involves only db views, no crud needed

        public override void Up()
        {
            //CreateTable(
            //    "dbo.vwProductInventories",
            //    c => new
            //        {
            //            BinlotID = c.Guid(nullable: false),
            //            ProductSku = c.String(),
            //            BinNumber = c.String(),
            //            LotNumber = c.String(),
            //            Quantity = c.Int(nullable: false),
            //            ReceivedAt = c.DateTime(nullable: false),
            //            ExpirationDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.BinlotID);
            
            //CreateTable(
            //    "dbo.vwProductTransations",
            //    c => new
            //        {
            //            InventoryTransactionID = c.Guid(nullable: false),
            //            Sku = c.String(),
            //            TransactionType = c.Int(nullable: false),
            //            BinNumber = c.String(),
            //            LotNumber = c.String(),
            //            Quantity = c.Int(nullable: false),
            //            Username = c.String(),
            //            Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.InventoryTransactionID);
            
            //CreateTable(
            //    "dbo.vwUserSales",
            //    c => new
            //        {
            //            Username = c.String(nullable: false, maxLength: 128),
            //            Sku = c.String(),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            TotalQuantity = c.Int(nullable: false),
            //            TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.vwUserSales");
            //DropTable("dbo.vwProductTransations");
            //DropTable("dbo.vwProductInventories");
        }
    }
}

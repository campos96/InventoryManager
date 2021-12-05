namespace InventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInvTransactionUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryTransactions", "Username", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.InventoryTransactions", "Username");
            AddForeignKey("dbo.InventoryTransactions", "Username", "dbo.Users", "UserName", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryTransactions", "Username", "dbo.Users");
            DropIndex("dbo.InventoryTransactions", new[] { "Username" });
            DropColumn("dbo.InventoryTransactions", "Username");
        }
    }
}

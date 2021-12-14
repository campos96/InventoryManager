namespace InventoryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFixedNamesForDbViews : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.vwProductInventories", newName: "vwProductInventory");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.vwProductInventory", newName: "vwProductInventories");
        }
    }
}

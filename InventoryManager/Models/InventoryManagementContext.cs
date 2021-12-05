using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class InventoryManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Bin> Bins { get; set; }

        public DbSet<Lot> Lots { get; set; }

        public DbSet<BinLot> BinLots { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
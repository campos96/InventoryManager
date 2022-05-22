using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class InventoryManagement_TestContext : DbContext
    {
        public InventoryManagement_TestContext()
        {
        }

        public InventoryManagement_TestContext(DbContextOptions<InventoryManagement_TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BinLots> BinLots { get; set; }
        public virtual DbSet<Bins> Bins { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual DbSet<Lots> Lots { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VwProductInventory> VwProductInventory { get; set; }
        public virtual DbSet<VwProductTransations> VwProductTransations { get; set; }
        public virtual DbSet<VwUserSales> VwUserSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-J46H7PM;Initial Catalog=InventoryManagement_Test;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

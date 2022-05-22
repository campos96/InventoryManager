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
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VwProductInventory> VwProductInventory { get; set; }
        public virtual DbSet<VwProductInventory2> VwProductInventory2 { get; set; }
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
            //modelBuilder.Entity<BinLots>(entity =>
            //{
            //    entity.HasIndex(e => e.BinNumber)
            //        .HasName("IX_BinNumber");

            //    entity.HasIndex(e => e.LotNumber)
            //        .HasName("IX_LotNumber");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.BinNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.LotNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.HasOne(d => d.BinNumberNavigation)
            //        .WithMany(p => p.BinLots)
            //        .HasForeignKey(d => d.BinNumber)
            //        .HasConstraintName("FK_dbo.BinLots_dbo.Bins_BinNumber");

            //    entity.HasOne(d => d.LotNumberNavigation)
            //        .WithMany(p => p.BinLots)
            //        .HasForeignKey(d => d.LotNumber)
            //        .HasConstraintName("FK_dbo.BinLots_dbo.Lots_LotNumber");
            //});

            //modelBuilder.Entity<Bins>(entity =>
            //{
            //    entity.HasKey(e => e.Number)
            //        .HasName("PK_dbo.Bins");

            //    entity.Property(e => e.Number).HasMaxLength(128);

            //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<Inventory>(entity =>
            //{
            //    entity.HasIndex(e => e.ProductSku)
            //        .HasName("IX_ProductSku");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.LastUpdate).HasColumnType("datetime");

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.HasOne(d => d.ProductSkuNavigation)
            //        .WithMany(p => p.Inventory)
            //        .HasForeignKey(d => d.ProductSku)
            //        .HasConstraintName("FK_dbo.Inventories_dbo.Products_ProductSku");
            //});

            //modelBuilder.Entity<InventoryTransactions>(entity =>
            //{
            //    entity.HasIndex(e => e.BinLotId)
            //        .HasName("IX_BinLotID");

            //    entity.HasIndex(e => e.Username)
            //        .HasName("IX_Username");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.BinLotId).HasColumnName("BinLotID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Username)
            //        .IsRequired()
            //        .HasMaxLength(128)
            //        .HasDefaultValueSql("('')");

            //    entity.HasOne(d => d.BinLot)
            //        .WithMany(p => p.InventoryTransactions)
            //        .HasForeignKey(d => d.BinLotId)
            //        .HasConstraintName("FK_dbo.InventoryTransactions_dbo.BinLots_BinLotID");

            //    entity.HasOne(d => d.UsernameNavigation)
            //        .WithMany(p => p.InventoryTransactions)
            //        .HasForeignKey(d => d.Username)
            //        .HasConstraintName("FK_dbo.InventoryTransactions_dbo.Users_Username");
            //});

            //modelBuilder.Entity<Lots>(entity =>
            //{
            //    entity.HasKey(e => e.Number)
            //        .HasName("PK_dbo.Lots");

            //    entity.HasIndex(e => e.ProductSku)
            //        .HasName("IX_ProductSku");

            //    entity.Property(e => e.Number).HasMaxLength(128);

            //    entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ReceivedAt).HasColumnType("datetime");

            //    entity.HasOne(d => d.ProductSkuNavigation)
            //        .WithMany(p => p.Lots)
            //        .HasForeignKey(d => d.ProductSku)
            //        .HasConstraintName("FK_dbo.Lots_dbo.Products_ProductSku");
            //});

            //modelBuilder.Entity<MigrationHistory>(entity =>
            //{
            //    entity.HasKey(e => new { e.MigrationId, e.ContextKey })
            //        .HasName("PK_dbo.__MigrationHistory");

            //    entity.ToTable("__MigrationHistory");

            //    entity.Property(e => e.MigrationId).HasMaxLength(150);

            //    entity.Property(e => e.ContextKey).HasMaxLength(300);

            //    entity.Property(e => e.Model).IsRequired();

            //    entity.Property(e => e.ProductVersion)
            //        .IsRequired()
            //        .HasMaxLength(32);
            //});

            //modelBuilder.Entity<ProductDetails>(entity =>
            //{
            //    entity.HasIndex(e => e.ProductSku)
            //        .HasName("IX_ProductSku");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Details).IsRequired();

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.HasOne(d => d.ProductSkuNavigation)
            //        .WithMany(p => p.ProductDetails)
            //        .HasForeignKey(d => d.ProductSku)
            //        .HasConstraintName("FK_dbo.ProductDetails_dbo.Products_ProductSku");
            //});

            //modelBuilder.Entity<ProductImages>(entity =>
            //{
            //    entity.HasIndex(e => e.ProductSku)
            //        .HasName("IX_ProductSku");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.FileName).IsRequired();

            //    entity.Property(e => e.FileType).IsRequired();

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ServerFileName).IsRequired();

            //    entity.HasOne(d => d.ProductSkuNavigation)
            //        .WithMany(p => p.ProductImages)
            //        .HasForeignKey(d => d.ProductSku)
            //        .HasConstraintName("FK_dbo.ProductImages_dbo.Products_ProductSku");
            //});

            //modelBuilder.Entity<Products>(entity =>
            //{
            //    entity.HasKey(e => e.Sku)
            //        .HasName("PK_dbo.Products");

            //    entity.Property(e => e.Sku).HasMaxLength(128);

            //    entity.Property(e => e.Brand).IsRequired();

            //    entity.Property(e => e.Name).IsRequired();

            //    entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            //});

            //modelBuilder.Entity<Users>(entity =>
            //{
            //    entity.HasKey(e => e.UserName)
            //        .HasName("PK_dbo.Users");

            //    entity.Property(e => e.UserName).HasMaxLength(128);

            //    entity.Property(e => e.LastName).IsRequired();

            //    entity.Property(e => e.Name).IsRequired();
            //});

            //modelBuilder.Entity<VwProductInventory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("vwProductInventory");

            //    entity.Property(e => e.BinNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.BinlotId).HasColumnName("BinlotID");

            //    entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ReceivedAt).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<VwProductInventory2>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("vwProductInventory2");

            //    entity.Property(e => e.BinNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.BinlotId).HasColumnName("BinlotID");

            //    entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

            //    entity.Property(e => e.LotNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ProductSku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.ReceivedAt).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<VwProductTransations>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("vwProductTransations");

            //    entity.Property(e => e.BinNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.InventoryTransactionId).HasColumnName("InventoryTransactionID");

            //    entity.Property(e => e.LotNumber)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.Sku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.Username)
            //        .IsRequired()
            //        .HasMaxLength(128);
            //});

            //modelBuilder.Entity<VwUserSales>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("vwUserSales");

            //    entity.Property(e => e.Sku)
            //        .IsRequired()
            //        .HasMaxLength(128);

            //    entity.Property(e => e.TotalPrice).HasColumnType("decimal(29, 2)");

            //    entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Username)
            //        .IsRequired()
            //        .HasMaxLength(128);
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

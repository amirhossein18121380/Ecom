using System;
using System.Collections.Generic;
using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Concrete.Context
{
    public partial class EcomContext : DbContext
    {
        public EcomContext()
        {
        }

        public EcomContext(DbContextOptions<EcomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductReceipt> ProductReceipts { get; set; } = null!;
        public virtual DbSet<ProductSaleFactor> ProductSaleFactors { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<SaleFactor> SaleFactors { get; set; } = null!;
        //public virtual DbSet<SaleFactorItem> SaleFactorItem { get; set; } = null!;
        //public virtual DbSet<ReceivedItems> ReceivedItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GGN4ULV;Initial Catalog=Ecom;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

               //entity.Property(e => e.Createon).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Createon).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");
            });

            modelBuilder.Entity<ProductReceipt>(entity =>
            {
                entity.ToTable("ProductReceipt");
            });

            modelBuilder.Entity<ProductSaleFactor>(entity =>
            {
                entity.ToTable("ProductSaleFactor");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.Property(e => e.ReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.TotalCost).HasColumnType("money");
            });

            modelBuilder.Entity<SaleFactor>(entity =>
            {
                entity.ToTable("SaleFactor");

                entity.Property(e => e.ReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.TotalCost).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

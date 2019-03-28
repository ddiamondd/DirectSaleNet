using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

//数据库上下文文件

namespace DirectSaleNet.Models
{
    public partial class DirectSaleContext : DbContext
    {
        //public DirectSaleContext()
        //{
        //}

        //public DirectSaleContext(DbContextOptions<DirectSaleContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Manufactor> Manufactor { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddInMemoryCollection()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                optionsBuilder.UseSqlServer(config["ConnectionString:SqlServer"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufactor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.ContactTel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Province).HasMaxLength(10);

                entity.Property(e => e.RegistDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Brand).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ManufactorId).HasColumnName("ManufactorID");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.Spec).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ManufactorId).HasColumnName("ManufactorID");

                entity.Property(e => e.NickName).HasMaxLength(20);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });
        }
    }
}

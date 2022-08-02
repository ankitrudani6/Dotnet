using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ToyCompany.Models
{
    public partial class ToyCompanyContext : DbContext
    {
        public ToyCompanyContext()
        {
        }

        public ToyCompanyContext(DbContextOptions<ToyCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderToy> OrderToys { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source = PC0345\\MSSQL2019;Database=ToyCompany;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .HasColumnName("Address");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38CDFA73A7")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534FF6CC333")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<ManufacturingPlant>(entity =>
            {
                entity.HasKey(e => e.PlantId)
                    .HasName("PK__Manufact__98FE46BC21B6EDBF");

                entity.ToTable("ManufacturingPlant");

                entity.Property(e => e.PlantId).HasColumnName("PlantID");

                entity.Property(e => e.PlantName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Order_AddressID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_CustomerID");
            });

            modelBuilder.Entity<OrderToy>(entity =>
            {
                entity.ToTable("OrderToy");

                entity.Property(e => e.OrderToyId).HasColumnName("OrderToyID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ToyId).HasColumnName("ToyID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderToys)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderToy_OrderID");

                entity.HasOne(d => d.Toy)
                    .WithMany(p => p.OrderToys)
                    .HasForeignKey(d => d.ToyId)
                    .HasConstraintName("FK_OrderToy_ToyID");
            });

            modelBuilder.Entity<Toy>(entity =>
            {
                entity.ToTable("Toy");

                entity.Property(e => e.ToyId).HasColumnName("ToyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantId).HasColumnName("PlantID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ToyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.PlantId)
                    .HasConstraintName("FK_Toy_PlantID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

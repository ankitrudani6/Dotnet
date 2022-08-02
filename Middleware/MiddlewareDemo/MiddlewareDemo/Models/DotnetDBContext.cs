using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MiddlewareDemo.Models
{
    public partial class DotnetDBContext : DbContext
    {
        public DotnetDBContext()
        {
        }

        public DotnetDBContext(DbContextOptions<DotnetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExceptionLogging> ExceptionLoggings { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionLogging>(entity =>
            {
                entity.HasKey(e => e.Logid)
                    .HasName("PK_Tbl_ExceptionLoggingToDataBase");

                entity.ToTable("ExceptionLogging");

                entity.Property(e => e.ExceptionMsg)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ExceptionURL");

                entity.Property(e => e.Logdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

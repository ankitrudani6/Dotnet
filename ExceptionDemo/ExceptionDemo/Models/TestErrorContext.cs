using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExceptionDemo.Models
{
    public partial class TestErrorContext : DbContext
    {
        public TestErrorContext()
        {
        }

        public TestErrorContext(DbContextOptions<TestErrorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = PC0345\\MSSQL2019;Database=TestError;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrorId)
                    .HasName("PK__ErrorLog__358565CAC4BE34B6");

                entity.ToTable("ErrorLog");

                entity.Property(e => e.ErrorId).HasColumnName("ErrorID");

                entity.Property(e => e.MessageTxt)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

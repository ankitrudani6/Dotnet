using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JWTAuthenticationDemo.Models
{
    public partial class TEST1Context : DbContext
    {
        public TEST1Context()
        {
        }

        public TEST1Context(DbContextOptions<TEST1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = PC0345\\MSSQL2019;Database=TEST1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInfo");

                entity.HasIndex(e => e.PhoneNumber, "CK_User_PhoneNumber")
                    .IsUnique();

                entity.HasIndex(e => e.EmailAddress, "UQ__UserInfo__49A14740B23DE9C9")
                    .IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

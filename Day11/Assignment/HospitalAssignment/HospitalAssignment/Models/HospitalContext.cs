using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalAssignment.Models
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assistant> Assistants { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<DrugSummary> DrugSummaries { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<JsonData> JsonDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["HospitalDB"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Assistant>(entity =>
            {
                entity.Property(e => e.AssistantId).HasColumnName("AssistantID");

                entity.Property(e => e.AssistantName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Phone).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assistants)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Assistants_DepartmentID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Doctors_DepartmentID");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.Property(e => e.DrugId).HasColumnName("DrugID");

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrugSummary>(entity =>
            {
                entity.ToTable("DrugSummary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DrugId).HasColumnName("DrugID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.DrugSummaries)
                    .HasForeignKey(d => d.DrugId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DS_DrugID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.DrugSummaries)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DS_PatientID");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.AssistantId).HasColumnName("AssistantID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assistant)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AssistantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Patient_AssistantID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Patient_DoctorID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

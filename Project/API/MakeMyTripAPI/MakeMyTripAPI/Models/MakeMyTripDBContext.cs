using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MakeMyTripAPI.Models
{
    public partial class MakeMyTripDBContext : DbContext
    {
        public MakeMyTripDBContext()
        {
        }

        public MakeMyTripDBContext(DbContextOptions<MakeMyTripDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightBooking> FlightBookings { get; set; }
        public virtual DbSet<FlightBookingLine> FlightBookingLines { get; set; }
        public virtual DbSet<FlightCode> FlightCodes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LoginInfo> LoginInfos { get; set; }
        public virtual DbSet<PassengerType> PassengerTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<ProfileInfo> ProfileInfos { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<TravelClass> TravelClasses { get; set; }
        public virtual DbSet<TripType> TripTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source = PC0345\\MSSQL2019;Database=MakeMyTripDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.HasIndex(e => e.AirLineName, "UQ__Airline__FE73F7272BAE180F")
                    .IsUnique();

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.AirLineName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountDiscription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpriedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

                entity.Property(e => e.FlightCodeId).HasColumnName("FlightCodeID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.FlightDestinations)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK_Flight_DestinationID");

                entity.HasOne(d => d.FlightCode)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.FlightCodeId)
                    .HasConstraintName("FK_Flight_FlightCodeID");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.FlightSources)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_Flight_SourceID");
            });

            modelBuilder.Entity<FlightBooking>(entity =>
            {
                entity.ToTable("FlightBooking");

                entity.HasIndex(e => e.Pnrno, "UQ__FlightBo__4677517ACC54D4B5")
                    .IsUnique();

                entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBooking)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.GstcompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GSTCompanyName");

                entity.Property(e => e.GstregistrationNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GSTRegistrationNo");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.NoOfPassenger).HasDefaultValueSql("((0))");

                entity.Property(e => e.PayableAmount).HasColumnType("money");

                entity.Property(e => e.Pnrno)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PNRNo");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TotalFare).HasColumnType("money");

                entity.Property(e => e.TotalSurcharge).HasColumnType("money");

                entity.Property(e => e.TravelClassId).HasColumnName("TravelClassID");

                entity.Property(e => e.TripTypeId).HasColumnName("TripTypeID");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.FlightBookings)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_FlightBooking_DiscountID");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.FlightBookings)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK_FlightBooking_ScheduleID");

                entity.HasOne(d => d.TravelClass)
                    .WithMany(p => p.FlightBookings)
                    .HasForeignKey(d => d.TravelClassId)
                    .HasConstraintName("FK_FlightBooking_TravelClassID");

                entity.HasOne(d => d.TripType)
                    .WithMany(p => p.FlightBookings)
                    .HasForeignKey(d => d.TripTypeId)
                    .HasConstraintName("FK_FlightBooking_TripTypeID");
            });

            modelBuilder.Entity<FlightBookingLine>(entity =>
            {
                entity.ToTable("FlightBookingLine");

                entity.Property(e => e.FlightBookingLineId).HasColumnName("FlightBookingLineID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PassengerTypeId).HasColumnName("PassengerTypeID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.FlightBooking)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.FlightBookingId)
                    .HasConstraintName("FK_FlightBookingLine_FlightBookingID");

                entity.HasOne(d => d.PassengerType)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.PassengerTypeId)
                    .HasConstraintName("FK_FlightBooking_PassengerTypeID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_FlightBookingLine_ProfileID");
            });

            modelBuilder.Entity<FlightCode>(entity =>
            {
                entity.ToTable("FlightCode");

                entity.Property(e => e.FlightCodeId).HasColumnName("FlightCodeID");

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.FlightCodeName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AirLine)
                    .WithMany(p => p.FlightCodes)
                    .HasForeignKey(d => d.AirLineId)
                    .HasConstraintName("FK_FlightCode_AirlineID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.HasIndex(e => e.LocationName, "UQ__Location__F946BB84B50C2AAA")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserID");

                entity.ToTable("LoginInfo");

                entity.HasIndex(e => e.EmailAddress, "UQ__LoginInf__49A1474052DE8D23")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__LoginInf__85FB4E38E2CF8B9B")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<PassengerType>(entity =>
            {
                entity.ToTable("PassengerType");

                entity.Property(e => e.PassengerTypeId).HasColumnName("PassengerTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PassengerTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.HasOne(d => d.FlightBooking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.FlightBookingId)
                    .HasConstraintName("FK_Payment_FlightBookingID");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_Payment_PaymentTypeID");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfileInfo>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PK_ProfileID");

                entity.ToTable("ProfileInfo");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IsTraveller)
                    .HasColumnName("isTraveller")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuingCountryId).HasColumnName("IssuingCountryID");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.IssuingCountry)
                    .WithMany(p => p.ProfileInfos)
                    .HasForeignKey(d => d.IssuingCountryId)
                    .HasConstraintName("FK_ProfileInfo_IssuingCountryID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProfileInfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProfileInfo_LoginInfo");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.BaseFare).HasColumnType("money");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Surcharges).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_Schedule_FlightID");
            });

            modelBuilder.Entity<TravelClass>(entity =>
            {
                entity.ToTable("TravelClass");

                entity.Property(e => e.TravelClassId).HasColumnName("TravelClassID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.TravelClassName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TripType>(entity =>
            {
                entity.ToTable("TripType");

                entity.Property(e => e.TripTypeId).HasColumnName("TripTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.TripTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

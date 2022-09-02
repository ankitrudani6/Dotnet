using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdvanceLINQPractice.Models
{
    public partial class makemytrip2435ankitContext : DbContext
    {
        public makemytrip2435ankitContext()
        {
        }

        public makemytrip2435ankitContext(DbContextOptions<makemytrip2435ankitContext> options)
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
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LoginInfo> LoginInfos { get; set; }
        public virtual DbSet<PassengerType> PassengerTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TravelClass> TravelClasses { get; set; }
        public virtual DbSet<TravellerInfo> TravellerInfos { get; set; }
        public virtual DbSet<TripType> TripTypes { get; set; }
        public virtual DbSet<VwFlightDetail> VwFlightDetails { get; set; }
        public virtual DbSet<VwSearchFlight> VwSearchFlights { get; set; }
        public virtual DbSet<VwTicketsDetail> VwTicketsDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = 43.204.134.14;Database=makemytrip-2435-ankit;User Id=makemytrip-2435-ankit;Password=SHsvdWKkJrxSzVF;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.HasIndex(e => e.AirLineCode, "UQ__Airline__ECDDFFEDECAB52BA")
                    .IsUnique();

                entity.HasIndex(e => e.AirLineName, "UQ__Airline__FE73F72784DED28A")
                    .IsUnique();

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.AirLineCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AirLineName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogoUrl).IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

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

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Success')");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TotalFare).HasColumnType("money");

                entity.Property(e => e.TotalSurcharge).HasColumnType("money");

                entity.Property(e => e.TravelClassId).HasColumnName("TravelClassID");

                entity.Property(e => e.TripTypeId).HasColumnName("TripTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FlightBookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FlightBooking_UserID");
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

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TravellerId).HasColumnName("TravellerID");

                entity.HasOne(d => d.FlightBooking)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.FlightBookingId)
                    .HasConstraintName("FK_FlightBookingLine_FlightBookingID");

                entity.HasOne(d => d.PassengerType)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.PassengerTypeId)
                    .HasConstraintName("FK_FlightBooking_PassengerTypeID");

                entity.HasOne(d => d.Traveller)
                    .WithMany(p => p.FlightBookingLines)
                    .HasForeignKey(d => d.TravellerId)
                    .HasConstraintName("FK_FlightBookingLine_TravellerID");
            });

            modelBuilder.Entity<FlightCode>(entity =>
            {
                entity.Property(e => e.FlightCodeId).HasColumnName("FlightCodeID");

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.FlightCode1).HasColumnName("FlightCode");

                entity.HasOne(d => d.AirLine)
                    .WithMany(p => p.FlightCodes)
                    .HasForeignKey(d => d.AirLineId)
                    .HasConstraintName("FK_FlightCode_AirlineID");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");

                entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");

                entity.Property(e => e.Charge).HasColumnType("money");

                entity.Property(e => e.InsuranceName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.HasIndex(e => e.LocationName, "UQ__Location__F946BB84B19B0B7E")
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

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<PassengerType>(entity =>
            {
                entity.Property(e => e.PassengerTypeId).HasColumnName("PassengerTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PassengerType1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PassengerType");
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

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FlightBooking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.FlightBookingId)
                    .HasConstraintName("FK_Payment_FlightBookingID");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_Payment_PaymentTypeID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Payment_userID");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PaymentType1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PaymentType");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.AvailableSeats).HasDefaultValueSql("((0))");

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

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Pnrno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PNRNo");

                entity.Property(e => e.TicketStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Confirmed')");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Tickets_PaymentID");
            });

            modelBuilder.Entity<TravelClass>(entity =>
            {
                entity.Property(e => e.TravelClassId).HasColumnName("TravelClassID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.TravelClass1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TravelClass");
            });

            modelBuilder.Entity<TravellerInfo>(entity =>
            {
                entity.HasKey(e => e.TravellerId)
                    .HasName("PK_TravellerID");

                entity.ToTable("TravellerInfo");

                entity.Property(e => e.TravellerId).HasColumnName("TravellerID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IssuingCountryId).HasColumnName("IssuingCountryID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.IssuingCountry)
                    .WithMany(p => p.TravellerInfos)
                    .HasForeignKey(d => d.IssuingCountryId)
                    .HasConstraintName("FK_TravllerInfo_IssuingCountryID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TravellerInfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TravellerInfo_LoginInfo");
            });

            modelBuilder.Entity<TripType>(entity =>
            {
                entity.Property(e => e.TripTypeId).HasColumnName("TripTypeID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.TripType1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TripType");
            });

            modelBuilder.Entity<VwFlightDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_FlightDetails");

                entity.Property(e => e.AirLineCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.AirLineName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationId).HasColumnName("DestinationID");

                entity.Property(e => e.FlightCodeId).HasColumnName("FlightCodeID");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");
            });

            modelBuilder.Entity<VwSearchFlight>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_searchFlight");

                entity.Property(e => e.AirLineCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AirLineName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BaseFare).HasColumnType("money");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogoUrl).IsUnicode(false);

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surcharges).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<VwTicketsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_TicketsDetails");

                entity.Property(e => e.DateOfBooking).HasColumnType("datetime");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");

                entity.Property(e => e.PayableAmount).HasColumnType("money");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pnrno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PNRNo");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.TicketStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

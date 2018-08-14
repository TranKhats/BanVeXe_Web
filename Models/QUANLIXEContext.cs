using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BanVeXe_Web.Models
{
    public partial class QUANLIXEContext : DbContext
    {
        public QUANLIXEContext()
        {
        }

        public QUANLIXEContext(DbContextOptions<QUANLIXEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<BookedSeat> BookedSeat { get; set; }
        public virtual DbSet<BuyService> BuyService { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DeatailClass> DeatailClass { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TypePlane> TypePlane { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-LIJ5HIK\SQLEXPRESS;Initial Catalog=QUANLIXE;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<BookedSeat>(entity =>
            {
                entity.HasKey(e => e.IdSeat)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("BOOKED_SEAT");

                entity.Property(e => e.IdSeat)
                    .HasColumnName("ID_SEAT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Col).HasColumnName("COL");

                entity.Property(e => e.IdFlight)
                    .IsRequired()
                    .HasColumnName("ID_FLIGHT")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Row).HasColumnName("ROW");

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.BookedSeat)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOOKED_SEAT_FLIGHT");
            });

            modelBuilder.Entity<BuyService>(entity =>
            {
                entity.HasKey(e => new { e.IdTicket, e.IdService });

                entity.ToTable("BUY_SERVICE");

                entity.HasIndex(e => e.IdService)
                    .HasName("BUY_SERVICE2_FK");

                entity.HasIndex(e => e.IdTicket)
                    .HasName("BUY_SERVICE_FK");

                entity.Property(e => e.IdTicket)
                    .HasColumnName("ID_TICKET")
                    .HasMaxLength(10);

                entity.Property(e => e.IdService)
                    .HasColumnName("ID_SERVICE")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Amount).HasColumnName("AMOUNT");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.BuyService)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUY_SERV_BUY_SERVI_SERVICE");

                entity.HasOne(d => d.IdTicketNavigation)
                    .WithMany(p => p.BuyService)
                    .HasForeignKey(d => d.IdTicket)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUY_SERV_BUY_SERVI_TICKET");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.ToTable("CLASS");

                entity.Property(e => e.IdType)
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("TYPE_NAME")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Passport);

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Passport)
                    .HasColumnName("PASSPORT")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(100);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("BIRTHDATE")
                    .HasColumnType("date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30);

                entity.Property(e => e.PassportExpiry)
                    .HasColumnName("PASSPORT_EXPIRY")
                    .HasColumnType("date");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("SEX")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<DeatailClass>(entity =>
            {
                entity.HasKey(e => new { e.IdFlight, e.IdType });

                entity.ToTable("DEATAIL_CLASS");

                entity.Property(e => e.IdFlight)
                    .HasColumnName("ID_FLIGHT")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndingRow).HasColumnName("ENDING_ROW");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("money");

                entity.Property(e => e.StartingRow).HasColumnName("STARTING_ROW");

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.DeatailClass)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEATAIL_CLASS_FLIGHT");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.DeatailClass)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEATAIL_CLASS_CLASS");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver);

                entity.ToTable("DRIVER");

                entity.Property(e => e.IdDriver)
                    .HasColumnName("ID_DRIVER")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.IdFlight);

                entity.ToTable("FLIGHT");

                entity.Property(e => e.IdFlight)
                    .HasColumnName("ID_FLIGHT")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ending)
                    .HasColumnName("ENDING")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlightDetail).HasColumnName("FLIGHT_DETAIL");

                entity.Property(e => e.IdDriver)
                    .HasColumnName("ID_DRIVER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdPlane)
                    .IsRequired()
                    .HasColumnName("ID_PLANE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.IdRoute).HasColumnName("ID_ROUTE");

                entity.Property(e => e.Starting)
                    .HasColumnName("STARTING")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.IdDriver)
                    .HasConstraintName("FK_FLIGHT_DRIVER");

                entity.HasOne(d => d.IdPlaneNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.IdPlane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_PLANE");

                entity.HasOne(d => d.IdRouteNavigation)
                    .WithMany(p => p.Flight)
                    .HasForeignKey(d => d.IdRoute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FLIGHT_ROUTE");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.IdPlace)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PLACE");

                entity.Property(e => e.IdPlace)
                    .HasColumnName("ID_PLACE")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Introduction)
                    .HasColumnName("INTRODUCTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LinkImg)
                    .HasColumnName("LINK_IMG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placename)
                    .HasColumnName("PLACENAME")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.IdPlane)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PLANE");

                entity.HasIndex(e => e.IdType)
                    .HasName("BUS_TYPEOFBUS_FK");

                entity.Property(e => e.IdPlane)
                    .HasColumnName("ID_PLANE")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cols).HasColumnName("COLS");

                entity.Property(e => e.IdType)
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rows).HasColumnName("ROWS");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Plane)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_BUS_BUS_TYPEO_TYPE_BUS");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.IdRoute)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ROUTE");

                entity.HasIndex(e => e.IdDepacture)
                    .HasName("ROUTE_PLACE_FK");

                entity.HasIndex(e => e.IdDestination)
                    .HasName("PK_ROUTE_PLACE_FK");

                entity.Property(e => e.IdRoute).HasColumnName("ID_ROUTE");

                entity.Property(e => e.IdDepacture)
                    .HasColumnName("ID_DEPACTURE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdDestination)
                    .HasColumnName("ID_DESTINATION")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepactureNavigation)
                    .WithMany(p => p.RouteIdDepactureNavigation)
                    .HasForeignKey(d => d.IdDepacture)
                    .HasConstraintName("FK_ROUTE_ROUTE_PLA_PLACE");

                entity.HasOne(d => d.IdDestinationNavigation)
                    .WithMany(p => p.RouteIdDestinationNavigation)
                    .HasForeignKey(d => d.IdDestination)
                    .HasConstraintName("FK_ROUTE_PK_ROUTE__PLACE");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("SERVICE");

                entity.Property(e => e.IdService)
                    .HasColumnName("ID_SERVICE")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Explanation)
                    .HasColumnName("EXPLANATION")
                    .HasMaxLength(300);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("numeric(15, 0)");

                entity.Property(e => e.Servicename)
                    .HasColumnName("SERVICENAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TICKET");

                entity.Property(e => e.IdTicket)
                    .HasColumnName("ID_TICKET")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Export)
                    .HasColumnName("EXPORT")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCus)
                    .HasColumnName("ID_CUS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IdSeat)
                    .HasColumnName("ID_SEAT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCusNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdCus)
                    .HasConstraintName("FK_TICKET_CUSTOMER");

                entity.HasOne(d => d.IdSeatNavigation)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.IdSeat)
                    .HasConstraintName("FK_TICKET_VARIABLE_SEAT");
            });

            modelBuilder.Entity<TypePlane>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TYPE_PLANE");

                entity.Property(e => e.IdType)
                    .HasColumnName("ID_TYPE")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Typename)
                    .HasColumnName("TYPENAME")
                    .HasMaxLength(20);
            });
        }
    }
}

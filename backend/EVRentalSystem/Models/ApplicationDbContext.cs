using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EVRentalSystem.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ExtraFee> ExtraFees { get; set; }

    public virtual DbSet<Handover> Handovers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<LogHistory> LogHistories { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RentalOrder> RentalOrders { get; set; }

    public virtual DbSet<Renter> Renters { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleModel> VehicleModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F35FAEM\\SQLEXPRESS;Database=rental_ev_system;User Id=sa;Password=12345;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__Complain__A771F61CE8F0CE15");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("PENDING");

            entity.HasOne(d => d.Order).WithMany(p => p.Complaints).HasConstraintName("FK__Complaint__order__693CA210");

            entity.HasOne(d => d.Renter).WithMany(p => p.Complaints)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Complaint__rente__68487DD7");

            entity.HasOne(d => d.ResolveByStaff).WithMany(p => p.Complaints).HasConstraintName("FK__Complaint__resol__6A30C649");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__F8D6642374861119");

            entity.Property(e => e.SignedDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.Contracts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract__order___5535A963");
        });

        modelBuilder.Entity<ExtraFee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PK__ExtraFee__A19C8AFBC7F27A08");

            entity.Property(e => e.Amount).HasDefaultValue(0m);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.ExtraFees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExtraFee__order___5DCAEF64");
        });

        modelBuilder.Entity<Handover>(entity =>
        {
            entity.HasKey(e => e.HandoverId).HasName("PK__Handover__67DDAEB22F4AD4CD");

            entity.Property(e => e.HandoverTimestamp).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.Handovers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Handover__order___628FA481");

            entity.HasOne(d => d.Staff).WithMany(p => p.Handovers).HasConstraintName("FK__Handover__staff___6383C8BA");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image__DC9AC955EBBCA4E3");

            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<LogHistory>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Log_Hist__9E2397E08FDB8D5B");

            entity.Property(e => e.LogDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.LogHistories).HasConstraintName("FK__Log_Histo__user___6E01572D");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842FE71CEFB1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.IsRead).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__user___72C60C4A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__ED1FC9EA65F45C2A");

            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__order_i__59063A47");
        });

        modelBuilder.Entity<RentalOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__RentalOr__465962299AC99E39");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DepositAmount).HasDefaultValue(0m);
            entity.Property(e => e.PaymentStatus).HasDefaultValue("UNPAID");
            entity.Property(e => e.Status).HasDefaultValue("BOOKED");
            entity.Property(e => e.TotalAmount).HasDefaultValue(0m);

            entity.HasOne(d => d.PickupStation).WithMany(p => p.RentalOrderPickupStations).HasConstraintName("FK__RentalOrd__picku__5070F446");

            entity.HasOne(d => d.Renter).WithMany(p => p.RentalOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RentalOrd__rente__4E88ABD4");

            entity.HasOne(d => d.ReturnStation).WithMany(p => p.RentalOrderReturnStations).HasConstraintName("FK__RentalOrd__retur__5165187F");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.RentalOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RentalOrd__vehic__4F7CD00D");
        });

        modelBuilder.Entity<Renter>(entity =>
        {
            entity.HasKey(e => e.RenterId).HasName("PK__Renter__50438F0B859B0A03");

            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.Renters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Renter__user_id__44FF419A");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__1963DD9CC24FB798");

            entity.Property(e => e.HireDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Station).WithMany(p => p.Staff).HasConstraintName("FK__Staff__station_i__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__user_id__3D5E1FD2");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Station__44B370E95E51C120");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F2066EEE2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Role).HasDefaultValue("RENTER");
            entity.Property(e => e.Status).HasDefaultValue("Active");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__F2947BC100923C4A");

            entity.Property(e => e.Condition).HasDefaultValue("GOOD");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.CurrentMileage).HasDefaultValue(0);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Station).WithMany(p => p.Vehicles).HasConstraintName("FK__Vehicle__station__30F848ED");

            entity.HasOne(d => d.VehicleModel).WithMany(p => p.Vehicles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehicle__vehicle__31EC6D26");
        });

        modelBuilder.Entity<VehicleModel>(entity =>
        {
            entity.HasKey(e => e.VehicleModelId).HasName("PK__Vehicle___79AAE30D46076DE8");

            entity.Property(e => e.NumberOfSeats).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

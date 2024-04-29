using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookingdatum> Bookingdata { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Roomdatum> Roomdata { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookingdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bookingd__3213E83F8F7EC8C8");

            entity.ToTable("bookingdata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.Guests).HasColumnName("guests");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Startdate)
                .HasColumnType("datetime")
                .HasColumnName("startdate");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookingdata)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__roomi__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.Bookingdata)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__useri__5165187F");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Quality).HasName("PK__prices__B9B86FE69F572606");

            entity.ToTable("prices");

            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quality");
            entity.Property(e => e.Price1).HasColumnName("price");
        });

        modelBuilder.Entity<Roomdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roomdata__3213E83F1FCC92A6");

            entity.ToTable("roomdata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Beds).HasColumnName("beds");
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quality");

            entity.HasOne(d => d.QualityNavigation).WithMany(p => p.Roomdata)
                .HasForeignKey(d => d.Quality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__roomdata__qualit__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F6C63F40D");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

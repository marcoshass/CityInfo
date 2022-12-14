using System;
using System.Collections.Generic;
using CityInfo.Core.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentType> AppointmentTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasIndex(e => e.ScheduleId, "IX_Appointments_ScheduleId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsPotentiallyConflicting)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.TimeRangeEnd).HasColumnName("TimeRange_End");
            entity.Property(e => e.TimeRangeStart).HasColumnName("TimeRange_Start");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Schedule).WithMany(p => p.Appointments).HasForeignKey(d => d.ScheduleId);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.PreferredName).HasMaxLength(50);
            entity.Property(e => e.Salutation).HasMaxLength(50);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Patients_ClientId");

            entity.Property(e => e.AnimalTypeBreed)
                .HasMaxLength(50)
                .HasColumnName("AnimalType_Breed");
            entity.Property(e => e.AnimalTypeSpecies)
                .HasMaxLength(50)
                .HasColumnName("AnimalType_Species");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.Patients).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

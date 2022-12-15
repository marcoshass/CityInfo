using System;
using System.Collections.Generic;
using System.Reflection;
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
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<AppointmentType> AppointmentTypes { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

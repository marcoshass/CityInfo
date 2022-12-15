using CityInfo.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.Data.EFMappings
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> entity)
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
        }
    }
}

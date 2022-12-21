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
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasIndex(e => e.ScheduleId, "IX_Appointments_ScheduleId");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.IsPotentiallyConflicting)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            builder.Property(e => e.TimeRangeEnd).HasColumnName("TimeRange_End");
            builder.Property(e => e.TimeRangeStart).HasColumnName("TimeRange_Start");
            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Schedule).WithMany(p => p.Appointments).HasForeignKey(d => d.ScheduleId);
        }
    }
}

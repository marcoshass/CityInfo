using FrontDesk.Core.ScheduleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDesk.Infrastructure.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Ignore(s => s.DateRange);
        }
    }
}

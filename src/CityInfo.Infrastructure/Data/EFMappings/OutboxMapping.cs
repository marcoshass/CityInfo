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
    public class OutboxMapping : IEntityTypeConfiguration<Outbox>
    {
        public void Configure(EntityTypeBuilder<Outbox> builder)
        {
            builder.ToTable(nameof(Outbox));
            builder.Property(e => e.Id)
                .ValueGeneratedNever();
            builder.Property(e => e.aggregate_type)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.aggregate_id)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.type)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.payload)
                .IsRequired()
                .HasColumnType("text")
                .IsUnicode(false);
        }
    }
}

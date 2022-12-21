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
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(e => e.EmailAddress).HasMaxLength(50);
            builder.Property(e => e.FullName).HasMaxLength(50);
            builder.Property(e => e.PreferredName).HasMaxLength(50);
            builder.Property(e => e.Salutation).HasMaxLength(50);
        }
    }
}

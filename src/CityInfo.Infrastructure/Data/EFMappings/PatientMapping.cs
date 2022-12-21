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
    public class PatientMapping : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasIndex(e => e.ClientId, "IX_Patients_ClientId");

            builder.Property(e => e.AnimalTypeBreed)
                .HasMaxLength(50)
                .HasColumnName("AnimalType_Breed");
            builder.Property(e => e.AnimalTypeSpecies)
                .HasMaxLength(50)
                .HasColumnName("AnimalType_Species");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Sex).HasMaxLength(50);

            builder.HasOne(d => d.Client).WithMany(p => p.Patients).HasForeignKey(d => d.ClientId);

        }
    }
}

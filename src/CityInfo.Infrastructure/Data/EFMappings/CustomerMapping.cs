using CityInfo.Core.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInfo.Infrastructure.Data.EFMappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(k => k.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(80);
            builder.Property(e => e.LastName).HasMaxLength(80);
            builder.Property(e => e.Phone).HasMaxLength(30);
            builder.OwnsOne(e => e.Address, e =>
            {
                e.Property(e1 => e1.Address1).HasColumnName("Address_Address1").HasMaxLength(100);
                e.Property(e1 => e1.Address2).HasColumnName("Address_Address2").HasMaxLength(100);
                e.Property(e1 => e1.City).HasColumnName("Address_City").HasMaxLength(50);
                e.Property(e1 => e1.State).HasColumnName("Address_State").HasMaxLength(50);
                e.Property(e1 => e1.Zip).HasColumnName("Address_Zip").HasMaxLength(10);
            });
            builder.Metadata.FindNavigation(nameof(Customer.Address))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

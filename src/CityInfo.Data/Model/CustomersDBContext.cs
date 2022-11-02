using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Data.Model
{
    public partial class CustomersDBContext : IdentityDbContext<ApplicationUser>
    {
        public CustomersDBContext()
        { }

        public CustomersDBContext(DbContextOptions<CustomersDBContext> options)
            : base(options)
        { }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("tblCustomers");
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

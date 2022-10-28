using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CityInfo.Data.Entities
{
    public partial class MoviesDBContext : DbContext
    {
        public MoviesDBContext()
        {}

        public MoviesDBContext(DbContextOptions options)
            : base(options)
        {}

        internal virtual DbSet<TblMovie> TblMovies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblMovie");

                entity.Property(e => e.MovieId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MovieID");

                entity.Property(e => e.MovieRating)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MovieTitle).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

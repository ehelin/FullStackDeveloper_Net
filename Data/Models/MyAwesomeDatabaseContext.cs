using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class MyAwesomeDatabaseContext : DbContext
    {
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationDetails> LocationDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-T0D67EL\SQLEXPRESS;Database=MyAwesomeDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationiId);

                entity.ToTable("location", "myAwesomeDatabaseLocationSchema");

                entity.Property(e => e.LocationiId).HasColumnName("locationiId");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .HasColumnName("locationName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationDetails>(entity =>
            {
                entity.HasKey(e => e.LocationDetailId);

                entity.ToTable("locationDetails", "myAwesomeDatabaseLocationSchema");

                entity.Property(e => e.LocationDetailId).HasColumnName("locationDetailId");

                entity.Property(e => e.Food)
                    .HasColumnName("food")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.People)
                    .HasColumnName("people")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Weather)
                    .HasColumnName("weather")
                    .HasMaxLength(100)
                    .IsUnicode(false);
             });
        }
    }
}

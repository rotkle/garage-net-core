using Garage.Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL
{
    public class GarageDbContext : DbContext
    {
        public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options)
        {
        }

        public DbSet<Garages> Garages { get; set; }
        public DbSet<ParkingLevel> ParkingLevels { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garages>().ToTable("Garage");
            modelBuilder.Entity<ParkingLevel>().ToTable("ParkingLevel");
            modelBuilder.Entity<ParkingSpace>().ToTable("ParkingSpace");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");

            modelBuilder.Entity<Garages>(entity => 
            {
                entity.HasKey(e => e.GarageID);

                entity.Property(e => e.GarageName)
                      .IsRequired();
            });

            modelBuilder.Entity<ParkingLevel>(entity =>
            {
                entity.HasKey(e => e.ParkingLevelID);

                entity.Property(e => e.ParkingLevelName)
                      .IsRequired();

                entity.HasOne(e => e.Garage)
                    .WithMany(p => p.ParkingLevels)
                    .HasForeignKey(e => e.GarageID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ParkingSpace>(entity =>
            {
                entity.HasKey(e => e.ParkingSpaceID);

                entity.Property(e => e.ParkingSpaceName)
                      .IsRequired();

                entity.HasOne(e => e.ParkingLevel)
                    .WithMany(p => p.ParkingSpaces)
                    .HasForeignKey(e => e.ParkingLevelId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.VehicleType)
                    .WithMany(p => p.ParkingSpaces)
                    .HasForeignKey(e => e.VehicleTypeID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeID);

                entity.Property(e => e.Type)
                      .IsRequired();
            });
        }
    }
}

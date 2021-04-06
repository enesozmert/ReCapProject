using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapDemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=True;");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
        .Entity<Rental>()
        .HasOne(e => e.CustomerProp)
        .WithOne(e => e.RentalProp)
        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder
        .Entity<Customer>()
        .HasOne(e => e.RentalProp)
        .WithOne(e => e.CustomerProp)
        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder
        .Entity<Car>()
        .HasOne(e => e.BrandProp)
        .WithOne(e => e.CarProp)
        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder
        .Entity<Color>()
        .HasOne(e => e.CarProp)
        .WithOne(e => e.ColorProp)
        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder
        .Entity<Brand>()
        .HasOne(e => e.CarProp)
        .WithOne(e => e.BrandProp)
        .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder
        .Entity<CarImage>()
        .HasOne(e => e.CarProp)
        .WithOne(e => e.CarImageProp)
        .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

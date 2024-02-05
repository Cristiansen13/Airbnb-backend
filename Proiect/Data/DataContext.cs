using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<ApartmentOwner> ApartmentOwners { get; set; }
        public DbSet<ApartmentCategory> ApartmentCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentCategory>()
                    .HasKey(pc => new { pc.ApartmentId, pc.CategoryId });
            modelBuilder.Entity<ApartmentCategory>()
                    .HasOne(p => p.Apartment)
                    .WithMany(pc => pc.ApartmentCategories)
                    .HasForeignKey(p => p.ApartmentId);
            modelBuilder.Entity<ApartmentCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.ApartmentCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ApartmentOwner>()
                    .HasKey(po => new { po.ApartmentId, po.OwnerId });
            modelBuilder.Entity<ApartmentOwner>()
                    .HasOne(p => p.Apartment)
                    .WithMany(pc => pc.ApartmentPastOwners)
                    .HasForeignKey(p => p.ApartmentId);
            modelBuilder.Entity<ApartmentOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.ApartmentOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}

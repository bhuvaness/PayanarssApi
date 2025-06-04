// EF DbContext
using Microsoft.EntityFrameworkCore;
using ProductManagementModule.Models;

namespace ProductManagementModule.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductUnit> Unites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product ↔ ProductCategory (One-to-One)
            modelBuilder.Entity<Product>()
                               .HasOne(p => p.Category)
                               .WithMany()
                               .HasForeignKey(p => p.CategoryId)
                               .OnDelete(DeleteBehavior.Restrict);

            // Product ↔ ProductUnit (One-to-One)
            modelBuilder.Entity<Product>()
                               .HasOne(p => p.UnitId)
                               .WithMany()
                               .HasForeignKey(p => p.UnitId)
                               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
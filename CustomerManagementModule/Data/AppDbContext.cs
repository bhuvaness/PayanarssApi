// EF DbContext
using Microsoft.EntityFrameworkCore;
using CustomerManagementModule.Models;

namespace CustomerManagementModule.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerAddressMap> CustomerAddressMaps { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer ↔ Address (via CustomerAddressMap)
            modelBuilder.Entity<CustomerAddressMap>()
                .HasOne(m => m.Customer)
                .WithMany(c => c.CustomerAddresses)
                .HasForeignKey(m => m.CustomerId);

            modelBuilder.Entity<CustomerAddressMap>()
                .HasOne(m => m.Address)
                .WithMany(a => a.CustomerMappings)
                .HasForeignKey(m => m.AddressId);

            // Customer ↔ Contact (One-to-Many)
            modelBuilder.Entity<CustomerContact>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CustomerId);

            // Customer ↔ CustomerType (One-to-Many)
            modelBuilder.Entity<CustomerType>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.CustomerTypes)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
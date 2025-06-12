namespace PlanNetsModule.Data
{
    using global::PlanNetsModule.DMs;
    using Microsoft.EntityFrameworkCore;

    namespace PlanNetsModule.Data
    {
        public class PlanNetsDbContext : DbContext
        {
            public PlanNetsDbContext(DbContextOptions<PlanNetsDbContext> options)
                : base(options)
            {
            }
            public DbSet<Plan> Plans { get; set; }
            public DbSet<PlanType> PlanTypes { get; set; }
            public DbSet<PlanStatus> PlanStatuses { get; set; }
            public DbSet<PlanPurpose> PlanPurposes { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Plan>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                    entity.Property(e => e.FromDateTime).IsRequired();
                    entity.Property(e => e.ToDateTime).IsRequired();

                    entity.HasOne(e => e.PlanType)
                          .WithMany(p => p.Plans)
                          .HasForeignKey(e => e.PlanTypeId);

                    entity.HasOne(e => e.PlanStatus)
                          .WithMany(p => p.Plans)
                          .HasForeignKey(e => e.PlanStatusId);
                });

                modelBuilder.Entity<PlanType>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<PlanStatus>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<PlanPurpose>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                });
            }
        }
    }
}

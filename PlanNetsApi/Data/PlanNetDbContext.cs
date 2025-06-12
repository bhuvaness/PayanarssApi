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
            public DbSet<Plan> Plan { get; set; }
            public DbSet<PlanType> PlanType { get; set; }
            public DbSet<PlanStatus> PlanStatus { get; set; }
            public DbSet<PlanPurpose> PlanPurpose { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Plan>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired();
                    entity.Property(e => e.FromDateTime).IsRequired();
                    entity.Property(e => e.ToDateTime).IsRequired();
                    entity.Ignore(e => e.IsDirty);
                    entity.Ignore(e => e.IsNew);
                });

                modelBuilder.Entity<PlanType>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Ignore(e => e.IsDirty);
                    entity.Ignore(e => e.IsNew);
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<PlanStatus>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Ignore(e => e.IsDirty);
                    entity.Ignore(e => e.IsNew); 
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<PlanPurpose>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Ignore(e => e.IsDirty);
                    entity.Ignore(e => e.IsNew); 
                    entity.Property(e => e.Name).IsRequired();
                });
            }
        }
    }
}

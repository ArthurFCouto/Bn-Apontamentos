using Microsoft.EntityFrameworkCore;

namespace BN.Apontamentos.Infrastructure.Context
{
    public class BnDbContext : DbContext
    {
        public BnDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BnDbContext).Assembly);
        }
    }
}

using BN.Apontamentos.Domain.AreasOperacionais.Schemas;
using BN.Apontamentos.Domain.Bobinas.Schemas;
using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;
using BN.Apontamentos.Domain.Trechos.Schemas;
using BN.Apontamentos.Domain.Usuarios.Schemas;
using Microsoft.EntityFrameworkCore;

namespace BN.Apontamentos.Infrastructure.Context
{
    public class BnDbContext : DbContext
    {
        public BnDbContext(DbContextOptions<BnDbContext> options) : base(options) { }
        public DbSet<AreaOperacional> AreaOperacional { get; set; }
        public DbSet<Bobina> Bobina { get; set; }
        public DbSet<PlanoDeCorte> PlanoDeCorte { get; set; }
        public DbSet<Trecho> Trecho { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BnDbContext).Assembly);
        }
    }
}

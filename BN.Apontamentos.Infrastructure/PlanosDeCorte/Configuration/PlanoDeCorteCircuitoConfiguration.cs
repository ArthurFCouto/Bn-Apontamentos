using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.PlanosDeCorte.Configuration
{
    public class PlanoDeCorteCircuitoConfiguration : IEntityTypeConfiguration<PlanoDeCorteCircuito>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCorteCircuito> builder)
        {
            builder.ToTable("PlanoDeCorteCircuito");

            builder.HasKey(pc => new { pc.IdPlanoDeCorte, pc.IdCircuito });

            builder.Property(pc => pc.IdPlanoDeCorte)
                .HasColumnName("id_plano_de_corte");

            builder.Property(pc => pc.IdCircuito)
                .HasColumnName("id_circuito");

            builder.HasOne(pc => pc.PlanoDeCorte)
                .WithMany(p => p.PlanoDeCorteCircuitos)
                .HasForeignKey(pc => pc.IdPlanoDeCorte);

            builder.HasOne(pc => pc.Circuito)
                .WithMany(p => p.PlanoDeCorteCircuitos)
                .HasForeignKey(pc => pc.IdCircuito);
        }
    }

}

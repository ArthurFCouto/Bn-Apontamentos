using BN.Apontamentos.Domain.Circuitos.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.Circuitos.Configuration
{
    internal class CircuitoConfiguration : IEntityTypeConfiguration<Circuito>
    {
        public void Configure(EntityTypeBuilder<Circuito> builder)
        {
            builder.ToTable("Circuito");

            builder.HasKey(p => p.IdCircuito);

            builder.Property(p => p.IdCircuito)
                .HasColumnName("id_circuito");

            builder.Property(p => p.Nome)
                .HasColumnName("nm_circuito");
        }
    }
}

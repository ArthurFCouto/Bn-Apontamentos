using BN.Apontamentos.Domain.AreasOperacionais.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.AreasOperacionais.Configuration
{
    public class AreaOperacionalConfiguration : IEntityTypeConfiguration<AreaOperacional>
    {
        public void Configure(EntityTypeBuilder<AreaOperacional> builder)
        {
            builder.ToTable("AreaOperacional");

            builder.HasKey(p => p.IdAreaOperacional);

            builder.Property(p => p.IdAreaOperacional)
                .HasColumnName("id_area_operacional");

            builder.Property(p => p.Descricao)
                .HasColumnName("nm_descricao")
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(p => p.DataInativacao)
                .HasColumnName("dt_data_inativacao");

            builder.HasMany(a => a.TrechosOrigem)
                .WithOne(t => t.Origem)
                .HasForeignKey(t => t.IdOrigem);

            builder.HasMany(a => a.TrechosDestino)
                .WithOne(t => t.Destino)
                .HasForeignKey(t => t.IdDestino);
        }
    }
}

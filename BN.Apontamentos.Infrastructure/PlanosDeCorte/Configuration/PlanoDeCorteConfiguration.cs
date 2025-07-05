using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.PlanosDeCorte.Configuration
{
    public class PlanoDeCorteConfiguration : IEntityTypeConfiguration<PlanoDeCorte>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCorte> builder)
        {
            builder.ToTable("PlanoDeCorte");

            builder.HasKey(p => p.IdPlanoDeCorte);

            builder.Property(p => p.IdPlanoDeCorte)
                .HasColumnName("id_plano_de_corte");

            builder.Property(p => p.Nome)
                .HasColumnName("nm_plano_de_corte")
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(p => p.DataInativacao)
                .HasColumnName("dt_data_inativacao");
        }
    }
}

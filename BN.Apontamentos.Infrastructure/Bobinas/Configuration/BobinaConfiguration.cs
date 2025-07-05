using BN.Apontamentos.Domain.Bobinas.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.Bobinas.Configuration
{
    public class BobinaConfiguration : IEntityTypeConfiguration<Bobina>
    {
        public void Configure(EntityTypeBuilder<Bobina> builder)
        {
            builder.ToTable("Bobina");

            builder.HasKey(p => p.IdBobina);

            builder.Property(p => p.IdBobina)
                .HasColumnName("id_bobina");

            builder.Property(p => p.Tag)
                .HasColumnName("nm_tag_bobina")
                .IsRequired();

            builder.Property(p => p.Comprimento)
                .HasColumnName("no_comprimento")
                .IsRequired();

            builder.Property(p => p.Secao)
                .HasColumnName("no_secao")
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(p => p.DataInativacao)
                .HasColumnName("dt_data_inativacao");
        }
    }
}

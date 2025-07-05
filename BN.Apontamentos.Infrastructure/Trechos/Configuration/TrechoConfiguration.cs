using BN.Apontamentos.Domain.Trechos.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.Trechos.Configuration
{
    public class TrechoConfiguration : IEntityTypeConfiguration<Trecho>
    {
        public void Configure(EntityTypeBuilder<Trecho> builder)
        {
            builder.ToTable("Trecho");

            builder.HasKey(p => p.IdTrecho);

            builder.Property(p => p.IdTrecho)
                .HasColumnName("id_trecho");

            builder.Property(p => p.Nome)
                .HasColumnName("nm_trecho")
                .IsRequired();

            builder.Property(p => p.Fase)
                .HasColumnName("cd_fase")
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(p => p.IdOrigem)
                .HasColumnName("id_origem")
                .IsRequired();

            builder.Property(p => p.IdDestino)
                .HasColumnName("id_destino")
                .IsRequired();

            builder.Property(p => p.IdPlanoDeCorte)
                .HasColumnName("id_plano_de_corte")
                .IsRequired();

            builder.Property(p => p.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(p => p.DataInativacao)
                .HasColumnName("dt_data_inativacao");

            builder.Property(p => p.IdBobina)
                .HasColumnName("id_bobina")
                .IsRequired();

            builder.Property(p => p.ComprimentoFase)
                .HasColumnName("no_comprimento_fase")
                .IsRequired();

            builder.HasOne(t => t.PlanoDeCorte)
                .WithMany(p => p.Trechos)
                .HasForeignKey(t => t.IdPlanoDeCorte);

            builder.HasOne(t => t.Origem)
                .WithMany(p => p.TrechosOrigem)
                .HasForeignKey(t => t.IdOrigem);

            builder.HasOne(t => t.Destino)
                .WithMany(p => p.TrechosDestino)
                .HasForeignKey(t => t.IdDestino);

            builder.HasOne(t => t.Bobina)
                .WithMany(p => p.Trechos)
                .HasForeignKey(t => t.IdBobina)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

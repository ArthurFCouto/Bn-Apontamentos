using BN.Apontamentos.Domain.Apontamentos.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.Apontamentos.Configuration
{
    public class ApontamentoConfiguration : IEntityTypeConfiguration<Apontamento>
    {
        public void Configure(EntityTypeBuilder<Apontamento> builder)
        {
            builder.ToTable("ApontamentoCabo");

            builder.HasKey(p => p.IdApontamento);

            builder.Property(p => p.IdApontamento)
                .HasColumnName("id_apontamento");

            builder.Property(p => p.NomeCircuito)
                .HasColumnName("nm_circuito");

            builder.Property(p => p.IdentificacaoCabo)
                .HasColumnName("ds_descricao_cabo");

            builder.Property(p => p.TagPrevisto)
                .HasColumnName("nm_tag_previsto");

            builder.Property(p => p.TagReal)
                .HasColumnName("nm_tag_real");

            builder.Property(p => p.Origem)
                .HasColumnName("nm_origem");

            builder.Property(p => p.Destino)
                .HasColumnName("nm_destino");

            builder.Property(p => p.Fase)
                .HasColumnName("cd_fase");

            builder.Property(p => p.ComprimentoFase)
                .HasColumnName("no_comprimento_fase");

            builder.Property(p => p.ComprimentoTotal)
                .HasColumnName("no_comprimento_total");

            builder.Property(p => p.Secao)
                .HasColumnName("no_secao");

            builder.Property(p => p.MetragemInicio)
                .HasColumnName("no_metragem_Inicio");

            builder.Property(p => p.MetragemFim)
                .HasColumnName("no_metragem_Fim");

            builder.Property(p => p.Observacao)
                .HasColumnName("tx_observacao");

            builder.Property(p => p.DataLancamento)
                .HasColumnName("dt_data_lancamento");

            builder.Property(p => p.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(p => p.DataModificacao)
                .HasColumnName("dt_data_modificacao");

            builder.Property(p => p.DataInativacao)
                .HasColumnName("dt_data_inativacao");

            builder.Property(p => p.IdPlanoDeCorte)
                .HasColumnName("id_plano_de_corte");

            builder.Property(p => p.IdTrecho)
                .HasColumnName("id_trecho");

            builder.Property(p => p.MatriculaUsuario)
                .HasColumnName("no_matricula_usuario");

            builder.HasOne(p => p.PlanoDeCorte)
                .WithMany()
                .HasForeignKey(p => p.IdPlanoDeCorte)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Trecho)
                .WithMany()
                .HasForeignKey(p => p.IdTrecho)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
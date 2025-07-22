using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Domain.Trechos.Entities;
using Mapster;

namespace BN.Apontamentos.Application.Trechos.Mappings
{
    public class ListarTrechoMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ListarTrechoEntity, ListarTrechoResponse>()
                  .Map(dest => dest.IdTrecho, src => src.Id_trecho)
                  .Map(dest => dest.IdPlanoDeCorte, src => src.Id_plano_de_corte)
                  .Map(dest => dest.Circuito, src => src.No_circuito)
                  .Map(dest => dest.IdentificacaoCabo, src => src.Nm_trecho)
                  .Map(dest => dest.TagPrevisto, src => src.Nm_tag_bobina)
                  .Map(dest => dest.Origem, src => src.Nm_origem)
                  .Map(dest => dest.IdOrigem, src => src.Id_origem)
                  .Map(dest => dest.Destino, src => src.Nm_destino)
                  .Map(dest => dest.IdDestino, src => src.Id_destino)
                  .Map(dest => dest.Fase, src => src.Cd_fase)
                  .Map(dest => dest.ComprimentoFase, src => src.No_comprimento_fase)
                  .Map(dest => dest.ComprimentoTodasFases, src => src.No_comprimento_todas_fases)
                  .Map(dest => dest.Secao, src => src.No_secao)
                  .Map(dest => dest.Ativo, src => src.Dt_data_inativacao == null);
        }
    }
}

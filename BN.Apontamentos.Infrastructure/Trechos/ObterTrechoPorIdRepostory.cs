using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Application.Trechos.Queries;
using BN.Apontamentos.Domain.Trechos.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace BN.Apontamentos.Infrastructure.Trechos
{
    internal class ObterTrechoPorIdRepostory
        : QueryHandler<ObterTrechoPorIdQuery, ObterTrechoPorIdResponse>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ObterTrechoPorIdRepostory(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;

        }

        protected override async Task<ObterTrechoPorIdResponse> ExecuteAsync(
            ObterTrechoPorIdQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            ListarTrechoEntity entity = await connection.QuerySingleOrDefaultAsync<ListarTrechoEntity>(query, parametros);

            if (entity is null)
            {
                return null;
            }

            return new ObterTrechoPorIdResponse()
            {
                IdTrecho = entity.Id_trecho,
                Circuito = entity.No_circuito,
                IdentificacaoCabo = entity.Nm_trecho,
                TagPrevisto = entity.Nm_tag_bobina,
                Origem = entity.Nm_origem,
                Destino = entity.Nm_destino,
                Fase = entity.Cd_fase,
                ComprimentoFase = entity.No_comprimento_fase,
                ComprimentoTodasFases = entity.No_comprimento_todas_fases,
                Secao = entity.No_secao,
                Ativo = entity.Dt_data_inativacao is null,
            };
        }

        private static DynamicParameters ObterParametros(ObterTrechoPorIdQuery request)
        {
            DynamicParameters parametros = new();
            parametros.Add("IdTrecho", request.Id);

            return parametros;
        }

        private const string query = @$"
                SELECT
                    tc.id_trecho,
                    tc.id_circuito as no_circuito,
                    tc.nm_trecho,
                    bb.nm_tag_bobina,
                    bb.no_secao,
                    ao.nm_descricao as nm_origem,
                    ad.nm_descricao as nm_destino,
                    tc.cd_fase,
                    tc.no_comprimento_fase,
                    tc.dt_data_inativacao
                FROM Trecho tc
                    INNER JOIN Bobina bb ON bb.id_bobina = tc.id_bobina 
                    INNER JOIN AreaOperacional ao ON ao.id_area_operacional = tc.id_origem
                    INNER JOIN AreaOperacional ad ON ad.id_area_operacional = tc.id_destino
                    INNER JOIN PlanoDeCorte pdc ON pdc.id_plano_de_corte = tc.id_plano_de_corte
                WHERE tc.id_trecho = @IdTrecho";
    }
}

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
                IdPlanoDeCorte = entity.Id_plano_de_corte,
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
                WITH InformacoesTrecho AS (
	                SELECT
	                    tc.id_trecho,
	                    tc.id_plano_de_corte,
                        tc.id_circuito as no_circuito,
	                    tc.nm_trecho,
	                    bb.id_bobina,
	                    bb.nm_tag_bobina,
	                    bb.no_secao,
	                    tc.id_origem,
	                    ao.nm_descricao as nm_origem,
	                    tc.id_destino,
	                    ad.nm_descricao as nm_destino,
	                    tc.cd_fase,
	                    tc.no_comprimento_fase
	                FROM Trecho tc
	                    INNER JOIN Bobina bb ON bb.id_bobina = tc.id_bobina 
	                    INNER JOIN AreaOperacional ao ON ao.id_area_operacional = tc.id_origem
	                    INNER JOIN AreaOperacional ad ON ad.id_area_operacional = tc.id_destino
	                    INNER JOIN PlanoDeCorte pdc ON pdc.id_plano_de_corte = tc.id_plano_de_corte
	                WHERE tc.dt_data_inativacao IS NULL
	                    AND tc.id_trecho = @IdTrecho
	                    ), Comprimento AS (
	    	                SELECT 
	    		                it.id_origem,
	    		                it.id_destino,
	    		                SUM(t_sum.no_comprimento_fase) AS no_comprimento_todas_fases
		                    FROM InformacoesTrecho it
		                    INNER JOIN Trecho t_sum ON t_sum.id_origem = it.id_origem
		                                    AND t_sum.id_destino = it.id_destino
		                                    AND t_sum.dt_data_inativacao IS NULL
		                    GROUP BY
		                        it.id_origem,
		                        it.id_destino
	                    )
	                SELECT
		                *
	                FROM InformacoesTrecho it
	                INNER JOIN Comprimento c ON c.id_origem = it.id_origem
	    		                AND c.id_destino = it.id_destino";
    }
}

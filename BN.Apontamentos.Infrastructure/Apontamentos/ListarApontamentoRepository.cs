using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Apontamentos.Queries;
using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Extensions;
using BN.Apontamentos.Domain.Apontamentos.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace BN.Apontamentos.Infrastructure.Apontamentos
{
    internal class ListarApontamentoRepository
        : QueryHandler<ListarApontamentoQuery, IEnumerable<ListarApontamentoResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarApontamentoRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }

        protected override async Task<IEnumerable<ListarApontamentoResponse>> ExecuteAsync(
            ListarApontamentoQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);
            string query = ObterQuery(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            IEnumerable<ListarApontamentoEntity> entities = await connection.QueryAsync<ListarApontamentoEntity>(query, parametros);

            IEnumerable<ListarApontamentoResponse> responses = entities.Select(e => new ListarApontamentoResponse
            {
                IdApontamento = e.Id_apontamento,
                Circuito = e.Nm_circuito,
                DescricaoCabo = e.Ds_descricaoCabo,
                TagPrevisto = e.Nm_tag_previsto,
                TagReal = e.Nm_tag_real,
                Origem = e.Nm_origem,
                Destino = e.Nm_destino,
                Fase = e.Cd_fase,
                ComprimentoFase = e.No_comprimento_fase,
                ComprimentoTotal = e.No_comprimento_total,
                Secao = e.No_secao,
                MetragemInicio = e.No_metragem_inicio,
                MetragemFim = e.No_metragem_Fim,
                Observacao = e.Tx_observacao,
                DataLancamento = e.Dt_data_lancamento
            }).ToArray();

            return responses;
        }

        private static DynamicParameters ObterParametros(ListarApontamentoQuery request)
        {
            DynamicParameters parametros = new();
            parametros.Add("IdPlanoDeCorte", request.IdPlanoDeCorte, DbType.String);
            parametros.Add("IdPlanoDeCorte", request.IdTrecho, DbType.String);

            return parametros;
        }

        private static string ObterQuery(ListarApontamentoQuery request)
        {
            return @$"
                SELECT
	                id_apontamento,
	                nm_circuito,
	                ds_descricao_cabo,
	                nm_tag_previsto,
	                nm_tag_real,
	                nm_origem,
	                nm_destino,
	                cd_fase,
	                no_comprimento_fase,
	                no_comprimento_total,
	                no_secao,
	                no_metragem_inicio,
	                no_metragem_fim,
	                tx_observacao,
	                dt_data_lancamento	
                FROM ApontamentoCabo ac
                WHERE 1 = 1
                    AND ac.dt_data_inativacao IS NULL
                    {request.IdPlanoDeCorte.AddDynamicParams("AND ac.id_plano_de_corte = @IdPlanoDeCorte")}
                    {request.IdTrecho.AddDynamicParams("AND ac.id_plano_de_corte = @IdTrecho")}";
        }
    }
}

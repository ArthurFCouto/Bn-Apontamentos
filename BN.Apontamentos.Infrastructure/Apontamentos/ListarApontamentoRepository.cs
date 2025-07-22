using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Apontamentos.Queries;
using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Common.Records;
using BN.Apontamentos.Application.Extensions;
using BN.Apontamentos.Domain.Apontamentos.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace BN.Apontamentos.Infrastructure.Apontamentos
{
    internal class ListarApontamentoRepository
        : QueryHandler<ListarApontamentoQuery, Record<ListarApontamentoResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarApontamentoRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }

        protected override async Task<Record<ListarApontamentoResponse>> ExecuteAsync(
            ListarApontamentoQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);
            string query = ObterQuery(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            IEnumerable<ListarApontamentoEntity> entities = await connection.QueryAsync<ListarApontamentoEntity>(query, parametros);
            return MapearResponse(entities, request);
        }

        private static DynamicParameters ObterParametros(ListarApontamentoQuery request)
        {
            DynamicParameters parametros = new();
            if (request.IdPlanoDeCorte.Any())
            {
                parametros.Add("IdPlanoDeCorte", request.IdPlanoDeCorte.Select(id => id).ToArray());
            }
            if (request.IdTrecho.Any())
            {
                parametros.Add("IdTrecho", request.IdTrecho.Select(id => id).ToArray());
            }
            parametros.Add("Offset", (request.PaginaAtual - 1) * request.QuantidadePorPagina);
            parametros.Add("QuantidadePorPagina", request.QuantidadePorPagina);

            return parametros;
        }

        private static string ObterQuery(ListarApontamentoQuery request)
        {
            return @$"
                SELECT
                    COUNT(*) OVER () AS no_total_registros,
                    CEILING(COUNT(*) OVER () / CAST(@QuantidadePorPagina AS FLOAT)) AS no_total_paginas,
	                id_apontamento,
	                no_circuito,
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
                    {request.IdPlanoDeCorte.AddDynamicParamsList("AND ac.id_plano_de_corte IN @IdPlanoDeCorte")}
                    {request.IdTrecho.AddDynamicParamsList("AND ac.id_trecho IN @IdTrecho")}
                    ORDER BY ac.id_apontamento ASC
                    OFFSET @Offset ROWS FETCH NEXT @QuantidadePorPagina ROWS ONLY";
        }

        private static Record<ListarApontamentoResponse> MapearResponse(
            IEnumerable<ListarApontamentoEntity> entities,
            ListarApontamentoQuery request)
        {
            if (entities is null || !entities.Any())
            {
                return new()
                {
                    TotalRegistros = 0,
                    TotalPaginas = 0,
                    Pagina = request.PaginaAtual,
                    QuantidadePorPagina = request.QuantidadePorPagina,
                    Registros = []
                };
            }

            return new()
            {
                TotalRegistros = entities.First().No_total_registros,
                TotalPaginas = entities.First().No_total_paginas,
                Pagina = request.PaginaAtual,
                QuantidadePorPagina = request.QuantidadePorPagina,
                Registros = entities.Select(e => new ListarApontamentoResponse
                {
                    IdApontamento = e.Id_apontamento,
                    Circuito = e.No_circuito,
                    DescricaoCabo = e.Ds_descricao_cabo,
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
                }).ToArray()
            };
        }
    }
}

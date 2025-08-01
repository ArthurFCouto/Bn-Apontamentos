﻿using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Extensions;
using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Application.Trechos.Queries;
using BN.Apontamentos.Domain.Trechos.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using Mapster;
using System.Data;

namespace BN.Apontamentos.Infrastructure.Trechos
{
    internal class ListarTrechoRepository
        : QueryHandler<ListarTrechoQuery, IEnumerable<ListarTrechoResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarTrechoRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }

        protected override async Task<IEnumerable<ListarTrechoResponse>> ExecuteAsync(
            ListarTrechoQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);
            string query = ObterQuery(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            IEnumerable<ListarTrechoEntity> entities = await connection.QueryAsync<ListarTrechoEntity>(query, parametros);

            entities
                .GroupBy(data => new { data.Id_origem, data.Id_destino })
                .ToList()
                .ForEach(grupo =>
                {
                    decimal comprimentoFase = grupo.Sum(data => data.No_comprimento_fase);

                    foreach (ListarTrechoEntity entity in grupo)
                    {
                        entity.No_comprimento_todas_fases = comprimentoFase;
                    }
                });

            return entities.Adapt<IEnumerable<ListarTrechoResponse>>();
        }

        private static DynamicParameters ObterParametros(ListarTrechoQuery request)
        {
            DynamicParameters parametros = new();
            if (request.IdPlanoDeCorte.Any())
            {
                parametros.Add("IdPlanoDeCorte", request.IdPlanoDeCorte.Select((id) => id).ToArray());
            }

            return parametros;
        }

        private static string ObterQuery(ListarTrechoQuery request)
        {
            return @$"
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
                WHERE 1 = 1
                    AND tc.dt_data_inativacao IS NULL
                    {request.IdPlanoDeCorte.AddDynamicParamsList("AND tc.id_plano_de_corte IN @IdPlanoDeCorte")}";
        }
    }
}

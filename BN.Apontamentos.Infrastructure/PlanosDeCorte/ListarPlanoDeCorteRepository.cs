using BN.Apontamentos.API.Extensions;
using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.PlanosDeCorte.Data;
using BN.Apontamentos.Application.PlanosDeCorte.Queries;
using BN.Apontamentos.Domain.PlanosDeCorte.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace BN.Apontamentos.Infrastructure.PlanosDeCorte
{
    internal class ListarPlanoDeCorteRepository
        : QueryHandler<ListarPlanoDeCorteQuery, IEnumerable<ListarPlanoDeCorteResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarPlanoDeCorteRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }

        protected override async Task<IEnumerable<ListarPlanoDeCorteResponse>> ExecuteAsync(
            ListarPlanoDeCorteQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);
            string query = ObterQuery(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            IEnumerable<ListarPlanoDeCorteEntity> entities = await connection.QueryAsync<ListarPlanoDeCorteEntity>(query, parametros);

            IEnumerable<ListarPlanoDeCorteResponse> response = entities
                .GroupBy(data => data.Nm_plano_de_corte)
                .Select(data =>
                {
                    ListarPlanoDeCorteEntity entity = data.FirstOrDefault();

                    ListarPlanoDeCorteResponse response = new()
                    {
                        Id = entity.Id_plano_de_corte,
                        Nome = entity.Nm_plano_de_corte,
                        Circuitos = data.Select(c => c.Id_circuito)
                                        .Where(c => c is not null)
                                        .ToList()
                    };

                    return response;
                });

            return response;
        }

        private static DynamicParameters ObterParametros(ListarPlanoDeCorteQuery request)
        {
            DynamicParameters parametros = new();
            parametros.Add("descricao", request.Descricao, DbType.String);

            return parametros;
        }

        private static string ObterQuery(ListarPlanoDeCorteQuery request)
        {
            return @$"
                SELECT
                    pc.id_plano_de_corte,
	                pc.nm_plano_de_corte,
	                c.id_circuito
                FROM PlanoDeCorte pc
	                LEFT JOIN PlanoDeCorteCircuito pcc ON pcc.id_plano_de_corte = pc.id_plano_de_corte
	                LEFT JOIN Circuito c ON c.id_circuito = pcc.id_circuito
                WHERE pc.dt_data_inativacao is NULL
                    {request.Descricao.AddDynamicParams("AND pc.nm_plano_de_corte = @descricao")}
                ORDER BY pc.nm_plano_de_corte";
        }
    }
}

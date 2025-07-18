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
    internal class ListarPlanoDeCorteComTrechoRepository
        : QueryHandler<ListarPlanoDeCorteComTrechoQuery, IEnumerable<ListarPlanoDeCorteComTrechoResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarPlanoDeCorteComTrechoRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }

        protected override async Task<IEnumerable<ListarPlanoDeCorteComTrechoResponse>> ExecuteAsync(
            ListarPlanoDeCorteComTrechoQuery request,
            CancellationToken cancellationToken)
        {
            DynamicParameters parametros = ObterParametros(request);
            string query = ObterQuery(request);

            using IDbConnection connection = dapperConnectionFactory.CreateConnection();
            IEnumerable<ListarPlanoDeCorteComTrechoEntity> entities = await connection.QueryAsync<ListarPlanoDeCorteComTrechoEntity>(query, parametros);

            IEnumerable<ListarPlanoDeCorteComTrechoResponse> response = entities
                .GroupBy(data => data.Id_plano_de_corte)
                .Select(data =>
                {
                    ListarPlanoDeCorteComTrechoEntity entity = data.FirstOrDefault();

                    ListarPlanoDeCorteComTrechoResponse response = new()
                    {
                        Id = entity.Id_plano_de_corte,
                        Nome = entity.Nm_plano_de_corte,
                        Trechos = data.Select(c => new ListarPlanoDeCorteComTrecho()
                        {
                            IdentificacaoCabo = c.Nm_trecho,
                            Id = c.Id_trecho
                        }).ToList()
                    };

                    return response;
                });

            return response;
        }

        private static DynamicParameters ObterParametros(ListarPlanoDeCorteComTrechoQuery request)
        {
            DynamicParameters parametros = new();
            parametros.Add("descricao", request.DescricaoPlano, DbType.String);

            return parametros;
        }

        private static string ObterQuery(ListarPlanoDeCorteComTrechoQuery request)
        {
            return @$"
                SELECT
	                pc.id_plano_de_corte,
	                pc.nm_plano_de_corte,
	                t.id_trecho,
	                t.nm_trecho
                FROM PlanoDeCorte pc
                INNER JOIN Trecho t ON t.id_plano_de_corte = pc.id_plano_de_corte
	                AND t.dt_data_inativacao  IS NULL
                WHERE 1 = 1
	                AND pc.dt_data_inativacao IS NULL
                    {request.DescricaoPlano.AddDynamicParams("AND pc.nm_plano_de_corte = @descricao")}
                ORDER BY pc.nm_plano_de_corte";
        }
    }
}

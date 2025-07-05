using BN.Apontamentos.API.Extensions;
using BN.Apontamentos.Application.PlanosDeCorte.Data;
using BN.Apontamentos.Application.PlanosDeCorte.Queries;
using BN.Apontamentos.Domain.PlanosDeCorte.Entities;
using BN.Apontamentos.Infrastructure.Persistence;
using Dapper;
using MediatR;
using System.Data;

namespace BN.Apontamentos.Infrastructure.PlanosDeCorte
{
    internal class ListarPlanoDeCorteRepository
        : IRequestHandler<ListarPlanoDeCorteQuery, IEnumerable<ListarPlanoDeCorteResponse>>
    {
        private readonly IDapperConnectionFactory dapperConnectionFactory;

        public ListarPlanoDeCorteRepository(IDapperConnectionFactory dapperConnectionFactory)
        {
            this.dapperConnectionFactory = dapperConnectionFactory;
        }
        public async Task<IEnumerable<ListarPlanoDeCorteResponse>> Handle(
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
                        Nome = entity.Nm_circuito,
                        Circuitos = data.Select(c => c.Nm_circuito).ToList()
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
	                c.nm_circuito
                FROM PlanoDeCorte pc
	                LEFT JOIN PlanoDeCorteCircuito pcc ON pcc.id_plano_de_corte = pc.id_plano_de_corte
	                LEFT JOIN Circuito c ON c.id_circuito = pcc.id_circuito
                WHERE 1 = 1
                    AND pc.dt_data_inativacao = NULL
                    {request.Descricao.AddDynamicParams("AND pc.nm_plano_de_corte = @descricao")}
                ORDER BY pc.nm_plano_de_corte";
        }
    }
}

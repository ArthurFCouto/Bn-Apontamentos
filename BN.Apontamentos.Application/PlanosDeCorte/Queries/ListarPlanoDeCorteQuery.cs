using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.PlanosDeCorte.Data;

namespace BN.Apontamentos.Application.PlanosDeCorte.Queries
{
    public class ListarPlanoDeCorteQuery
        : IQueryRequest<IEnumerable<ListarPlanoDeCorteResponse>>
    {
        public string Descricao { get; set; }
    }
}

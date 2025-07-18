using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.PlanosDeCorte.Data;

namespace BN.Apontamentos.Application.PlanosDeCorte.Queries
{
    public class ListarPlanoDeCorteComTrechoQuery
    : IQueryRequest<IEnumerable<ListarPlanoDeCorteComTrechoResponse>>
    {
        public string DescricaoPlano { get; set; }
    }
}

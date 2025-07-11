using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Common.Queries;

namespace BN.Apontamentos.Application.Apontamentos.Queries
{
    public class ListarApontamentoQuery
        : IQueryRequest<IEnumerable<ListarApontamentoResponse>>
    {
        public int? IdTrecho { get; set; }
        public int? IdPlanoDeCorte { get; set; }
    }
}

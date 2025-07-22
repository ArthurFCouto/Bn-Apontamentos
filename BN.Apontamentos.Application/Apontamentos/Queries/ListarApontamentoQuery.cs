using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.Common.Records;

namespace BN.Apontamentos.Application.Apontamentos.Queries
{
    public class ListarApontamentoQuery
        : IQueryRequest<Record<ListarApontamentoResponse>>
    {
        public IEnumerable<int> IdTrecho { get; set; }
        public IEnumerable<int> IdPlanoDeCorte { get; set; }
        public int PaginaAtual { get; set; }
        public int QuantidadePorPagina { get; set; }
    }
}

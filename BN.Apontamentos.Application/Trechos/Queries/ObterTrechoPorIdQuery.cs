using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.Trechos.Data;

namespace BN.Apontamentos.Application.Trechos.Queries
{
    public class ObterTrechoPorIdQuery
        : IQueryRequest<ObterTrechoPorIdResponse>
    {
        public int Id { get; set; }
    }
}

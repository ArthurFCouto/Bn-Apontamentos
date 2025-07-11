using BN.Apontamentos.Domain.Trechos.Schemas;
using MediatR;

namespace BN.Apontamentos.Domain.Trechos.Queries
{
    public class ObterTrechoPorIdModelQuery
        : IRequest<Trecho>
    {
        public int IdTrecho { get; set; }
        public bool IncluirPlanoDeCorte { get; set; }
        public bool IncluirCircuito { get; set; }
        public bool IncluirBobina { get; set; }
        public bool IncluirOrigem { get; set; }
        public bool IncluirDestino { get; set; }
    }
}

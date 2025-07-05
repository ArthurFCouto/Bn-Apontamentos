using MediatR;

namespace BN.Apontamentos.Application.Trechos.Data
{
    public class ListarTrechoRequest
        : IRequest<IEnumerable<ListarTrechoResponse>>
    {
        public int? IdPlanoDeCorte { get; set; }
    }
}

using BN.Apontamentos.Application.PlanosDeCorte.Data;
using MediatR;

namespace BN.Apontamentos.Application.PlanosDeCorte.Queries
{
    public class ListarPlanoDeCorteQuery
        : IRequest<IEnumerable<ListarPlanoDeCorteResponse>>
    {
        public string Descricao { get; set; }
    }
}

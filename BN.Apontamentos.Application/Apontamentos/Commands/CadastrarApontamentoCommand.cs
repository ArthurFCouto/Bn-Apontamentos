using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Common.Commands;

namespace BN.Apontamentos.Application.Apontamentos.Commands
{
    public class CadastrarApontamentoCommand
        : ICommandRequest<CadastrarApontamentoResponse>
    {
        public int IdTrecho { get; set; }
        public int MatriculaUsuario { get; set; }
        public string TagReal { get; set; }
        public decimal MetragemInicio { get; set; }
        public decimal MetragemFim { get; set; }
        public string Observacao { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}

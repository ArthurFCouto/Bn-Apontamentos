namespace BN.Apontamentos.Application.Apontamentos.Data
{
    public class ListarApontamentoRequest
    {
        public IEnumerable<int?> IdTrecho { get; set; }
        public IEnumerable<int?> IdPlanoDeCorte { get; set; }
        public int PaginaAtual { get; set; }
        public int QuantidadePorPagina { get; set; }
    }
}

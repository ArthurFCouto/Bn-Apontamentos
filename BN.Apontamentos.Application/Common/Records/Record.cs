namespace BN.Apontamentos.Application.Common.Records
{
    public class Record<T>
    {
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public IEnumerable<T> Registros { get; set; }
    }
}

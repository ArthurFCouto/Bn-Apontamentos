namespace BN.Apontamentos.Application.Apontamentos.Data
{
    public class ListarApontamentoResponse
    {
        public int IdApontamento { get; set; }
        public int Circuito { get; set; }
        public string DescricaoCabo { get; set; }
        public string TagPrevisto { get; set; }
        public string TagReal { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public char Fase { get; set; }
        public decimal ComprimentoFase { get; set; }
        public decimal ComprimentoTotal { get; set; }
        public decimal Secao { get; set; }
        public decimal MetragemInicio { get; set; }
        public decimal MetragemFim { get; set; }
        public string Observacao { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}

namespace BN.Apontamentos.Application.Trechos.Data
{
    public class ObterTrechoPorIdResponse
    {
        public int IdTrecho { get; set; }
        public int IdPlanoDeCorte { get; set; }
        public int Circuito { get; set; }
        public string IdentificacaoCabo { get; set; }
        public string TagPrevisto { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public char Fase { get; set; }
        public decimal ComprimentoFase { get; set; }
        public decimal ComprimentoTodasFases { get; set; }
        public decimal Secao { get; set; }
        public bool Ativo { get; set; }
    }
}
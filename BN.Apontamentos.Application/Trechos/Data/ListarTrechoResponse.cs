namespace BN.Apontamentos.Application.Trechos.Data
{
    public class ListarTrechoResponse
    {
        public int IdTrecho { get; set; }
        public int IdPlanoDeCorte { get; set; }
        public string IdentificacaoCabo { get; set; }
        public string TagPrevisto { get; set; }
        public string Origem { get; set; }
        public int IdOrigem { get; set; }
        public string Destino { get; set; }
        public int IdDestino { get; set; }
        public char Fase { get; set; }
        public float ComprimentoFase { get; set; }
        public float ComprimentoTodasFases { get; set; }
        public int Secao { get; set; }
    }
}

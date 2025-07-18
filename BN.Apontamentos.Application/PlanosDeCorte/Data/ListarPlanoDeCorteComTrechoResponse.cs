namespace BN.Apontamentos.Application.PlanosDeCorte.Data
{
    public class ListarPlanoDeCorteComTrechoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<ListarPlanoDeCorteComTrecho> Trechos { get; set; } = [];

    }

    public class ListarPlanoDeCorteComTrecho
    {
        public int Id { get; set; }
        public string IdentificacaoCabo { get; set; }
    }
}

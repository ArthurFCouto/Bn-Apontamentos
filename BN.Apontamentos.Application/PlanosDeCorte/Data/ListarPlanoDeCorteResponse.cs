namespace BN.Apontamentos.Application.PlanosDeCorte.Data
{
    public class ListarPlanoDeCorteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<string> Circuitos { get; set; } = [];

    }
}

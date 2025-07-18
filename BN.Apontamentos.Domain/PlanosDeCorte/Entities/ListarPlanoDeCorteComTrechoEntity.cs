namespace BN.Apontamentos.Domain.PlanosDeCorte.Entities
{
    public class ListarPlanoDeCorteComTrechoEntity
    {
        public int Id_plano_de_corte { get; set; }
        public string Nm_plano_de_corte { get; set; }
        public int Id_trecho { get; set; }
        public string Nm_trecho { get; set; }
    }
}

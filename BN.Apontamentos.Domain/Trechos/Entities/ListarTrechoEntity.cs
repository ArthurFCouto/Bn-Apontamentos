namespace BN.Apontamentos.Domain.Trechos.Entities
{
    public class ListarTrechoEntity
    {
        public int Id_trecho { get; set; }
        public int Id_plano_de_corte { get; set; }
        public int No_circuito { get; set; }
        public string Nm_trecho { get; set; }
        public string Nm_tag_bobina { get; set; }
        public int No_secao { get; set; }
        public int Id_origem { get; set; }
        public string Nm_origem { get; set; }
        public int Id_destino { get; set; }
        public string Nm_destino { get; set; }
        public char Cd_fase { get; set; }
        public decimal No_comprimento_fase { get; set; }
        public decimal No_comprimento_todas_fases { get; set; }
        public DateTime? Dt_data_inativacao { get; set; }
    }
}

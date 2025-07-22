namespace BN.Apontamentos.Domain.Apontamentos.Entities
{
    public class ListarApontamentoEntity
    {
        public int Id_apontamento { get; set; }
        public int No_total_registros { get; set; }
        public int No_total_paginas { get; set; }
        public int No_circuito { get; set; }
        public string Ds_descricao_cabo { get; set; }
        public string Nm_tag_previsto { get; set; }
        public string Nm_tag_real { get; set; }
        public string Nm_origem { get; set; }
        public string Nm_destino { get; set; }
        public char Cd_fase { get; set; }
        public decimal No_comprimento_fase { get; set; }
        public decimal No_comprimento_total { get; set; }
        public decimal No_secao { get; set; }
        public decimal No_metragem_inicio { get; set; }
        public decimal No_metragem_Fim { get; set; }
        public string Tx_observacao { get; set; }
        public DateTime Dt_data_lancamento { get; set; }
    }
}

using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;

namespace BN.Apontamentos.Domain.Circuitos.Schemas
{
    public class Circuito
    {
        public virtual int IdCircuito { get; set; }
        public virtual string Nome { get; set; }

        public virtual ICollection<PlanoDeCorteCircuito> PlanoDeCorteCircuitos { get; set; } = [];
    }
}

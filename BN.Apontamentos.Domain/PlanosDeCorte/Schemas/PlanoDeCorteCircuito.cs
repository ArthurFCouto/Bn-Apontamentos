using BN.Apontamentos.Domain.Circuitos.Schemas;

namespace BN.Apontamentos.Domain.PlanosDeCorte.Schemas
{
    public class PlanoDeCorteCircuito
    {
        protected PlanoDeCorteCircuito() { }

        public virtual int IdPlanoDeCorte { get; set; }
        public virtual int IdCircuito { get; set; }

        public virtual PlanoDeCorte PlanoDeCorte { get; set; } = null!;
        public virtual Circuito Circuito { get; set; } = null!;
    }
}

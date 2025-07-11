using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;
using BN.Apontamentos.Domain.Trechos.Schemas;

namespace BN.Apontamentos.Domain.Circuitos.Schemas
{
    public class Circuito
    {
        protected Circuito() { }

        public virtual int IdCircuito { get; set; }
        public virtual string Nome { get; set; }

        public virtual ICollection<PlanoDeCorteCircuito> PlanoDeCorteCircuitos { get; set; } = [];
        public virtual ICollection<Trecho> Trechos { get; set; } = [];
    }
}

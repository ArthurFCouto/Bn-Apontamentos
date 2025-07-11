using BN.Apontamentos.Domain.Trechos.Schemas;

namespace BN.Apontamentos.Domain.PlanosDeCorte.Schemas
{
    public class PlanoDeCorte
    {
        protected PlanoDeCorte() { }

        public virtual int IdPlanoDeCorte { get; private protected set; }
        public virtual string Nome { get; private protected set; }
        public virtual DateTime DataInclusao { get; private protected set; }
        public virtual DateTime? DataInativacao { get; private protected set; }

        public virtual ICollection<PlanoDeCorteCircuito> PlanoDeCorteCircuitos { get; private protected set; } = [];
        public virtual ICollection<Trecho> Trechos { get; private protected set; } = [];
    }
}

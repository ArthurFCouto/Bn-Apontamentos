using BN.Apontamentos.Domain.AreasOperacionais.Schemas;
using BN.Apontamentos.Domain.Bobinas.Schemas;
using BN.Apontamentos.Domain.Circuitos.Schemas;
using BN.Apontamentos.Domain.PlanosDeCorte.Schemas;

namespace BN.Apontamentos.Domain.Trechos.Schemas
{
    public partial class Trecho
    {
        protected Trecho() { }

        public virtual int IdTrecho { get; private protected set; }
        public virtual string Nome { get; private protected set; }
        public virtual char Fase { get; private protected set; }
        public virtual int IdOrigem { get; private protected set; }
        public virtual int IdDestino { get; private protected set; }
        public virtual int IdPlanoDeCorte { get; private protected set; }
        public virtual DateTime DataInclusao { get; private protected set; }
        public virtual DateTime? DataInativacao { get; private protected set; }
        public virtual int IdBobina { get; private protected set; }
        public virtual decimal ComprimentoFase { get; private protected set; }
        public virtual int IdCircuito { get; private protected set; }

        public virtual Bobina Bobina { get; private protected set; }
        public virtual AreaOperacional Origem { get; private protected set; }
        public virtual AreaOperacional Destino { get; private protected set; }
        public virtual PlanoDeCorte PlanoDeCorte { get; private protected set; }
        public virtual Circuito Circuito { get; private protected set; }
    }
}

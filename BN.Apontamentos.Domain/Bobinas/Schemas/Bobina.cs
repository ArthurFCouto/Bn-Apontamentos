using BN.Apontamentos.Domain.Trechos.Schemas;

namespace BN.Apontamentos.Domain.Bobinas.Schemas
{
    public partial class Bobina
    {
        protected Bobina() { }

        public virtual int IdBobina { get; private protected set; }
        public virtual string Tag { get; private protected set; }
        public virtual decimal Comprimento { get; private protected set; }
        public virtual int Secao { get; private protected set; }
        public virtual DateTime DataInclusao { get; private protected set; }
        public virtual DateTime? DataInativacao { get; private protected set; }

        public virtual ICollection<Trecho> Trechos { get; private protected set; }
    }
}

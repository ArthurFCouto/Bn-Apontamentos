using BN.Apontamentos.Domain.Trechos.Schemas;

namespace BN.Apontamentos.Domain.AreasOperacionais.Schemas
{
    public partial class AreaOperacional
    {
        public virtual int IdAreaOperacional { get; private protected set; }
        public virtual string Descricao { get; private protected set; }
        public virtual DateTime DataInclusao { get; private protected set; }
        public virtual DateTime? DataInativacao { get; private protected set; }

        public virtual ICollection<Trecho> TrechosOrigem { get; private protected set; } = [];
        public virtual ICollection<Trecho> TrechosDestino { get; private protected set; } = [];
    }
}

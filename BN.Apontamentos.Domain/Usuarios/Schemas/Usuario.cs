namespace BN.Apontamentos.Domain.Usuarios.Schemas
{
    public partial class Usuario
    {
        protected Usuario() { }

        public virtual int IdUsuario { get; private protected set; }
        public virtual string Nome { get; private protected set; }
        public virtual int Matricula { get; private protected set; }
        public virtual string Senha { get; private protected set; }
        public virtual DateTime DataInclusao { get; private protected set; }
        public virtual DateTime? DataModificacao { get; private protected set; }
        public virtual DateTime? DataInativacao { get; private protected set; }
    }
}

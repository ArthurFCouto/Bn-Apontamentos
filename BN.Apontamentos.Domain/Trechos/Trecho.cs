namespace BN.Apontamentos.Domain.Trechos.Schemas
{
    public partial class Trecho
    {
        public void InativarTrecho()
        {
            DataInativacao = DateTime.UtcNow;
        }
    }
}

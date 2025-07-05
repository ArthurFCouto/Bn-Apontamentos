namespace BN.Apontamentos.Infrastructure.Security.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(int id, int matricula, string nome, string role = null);
    }
}

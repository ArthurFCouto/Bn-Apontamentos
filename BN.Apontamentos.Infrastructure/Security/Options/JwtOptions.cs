namespace BN.Apontamentos.Infrastructure.Security.Options
{
    public class JwtOptions
    {
        public string JWT_SECRET { get; set; }
        public string JWT_ISSUER { get; set; }
        public string JWT_AUDIENCE { get; set; }
        public int JWT_EXPIRATION_MINUTES { get; set; }
    }
}

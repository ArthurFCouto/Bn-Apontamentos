using BN.Apontamentos.Infrastructure.Security.Interfaces;
using BN.Apontamentos.Infrastructure.Security.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BN.Apontamentos.Infrastructure.Security.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }

        public string GenerateToken(
            int id,
            int matricula,
            string nome,
            string role = null)
        {
            byte[] key = Encoding.UTF8.GetBytes(jwtOptions.JWT_SECRET);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new("id_user", $"{id}"),
                    new("no_matricula", $"{matricula}"),
                    new("nm_user", nome),
                    new Claim(ClaimTypes.Role, role ?? "role_user")
                ]),

                Expires = DateTime.UtcNow.AddMinutes(jwtOptions.JWT_EXPIRATION_MINUTES),
                Issuer = jwtOptions.JWT_ISSUER,
                Audience = jwtOptions.JWT_AUDIENCE,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new();
            string token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenConfig));

            return token;
        }
    }
}

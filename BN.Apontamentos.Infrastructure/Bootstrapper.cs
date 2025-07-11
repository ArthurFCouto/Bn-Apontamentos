using BN.Apontamentos.Domain.UnitOfWork;
using BN.Apontamentos.Infrastructure.Connection;
using BN.Apontamentos.Infrastructure.Context;
using BN.Apontamentos.Infrastructure.Persistence;
using BN.Apontamentos.Infrastructure.Security.Interfaces;
using BN.Apontamentos.Infrastructure.Security.Options;
using BN.Apontamentos.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BN.Apontamentos.Infrastructure
{
    public static class Bootstrapper
    {

        private static IServiceCollection AddDatabase(
            this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRINGS");

            services.AddDbContext<BnDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.Configure<DatabaseSettings>(o =>
                o.ConnectionString = connectionString);

            services.AddScoped<IDapperConnectionFactory, DapperConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services)
        {
            var jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtExpiration = Environment.GetEnvironmentVariable("JWT_EXPIRATION_MINUTES");

            var expirationMinutes = int.TryParse(jwtExpiration, out var minutes) ? minutes : 60;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = jwtAudience,
                    ValidateLifetime = true
                };
            });

            services.Configure<JwtOptions>(options =>
            {
                options.JWT_SECRET = jwtKey;
                options.JWT_ISSUER = jwtIssuer;
                options.JWT_AUDIENCE = jwtAudience;
                options.JWT_EXPIRATION_MINUTES = expirationMinutes;
            });

            return services;
        }

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddJwtAuthentication();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Bootstrapper).Assembly));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}

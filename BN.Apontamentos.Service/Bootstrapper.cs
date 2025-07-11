using Microsoft.Extensions.DependencyInjection;

namespace BN.Apontamentos.Service
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Registra os handlers do MediatR definidos nesta camada (BN.Apontamentos.Service).
        /// </summary>
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Bootstrapper).Assembly));

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace BN.Apontamentos.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Bootstrapper).Assembly));

            return services;
        }
    }
}

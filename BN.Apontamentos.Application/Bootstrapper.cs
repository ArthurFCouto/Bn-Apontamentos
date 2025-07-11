using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BN.Apontamentos.Application
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Adiciona automaticamente todos os validadores do FluentValidation localizados no assembly atual.
        /// </summary>
        public static IServiceCollection AddApplicationValidators(
            this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        /// <summary>
        /// Configura o Mapster e registra o IMapper com base nos mapeamentos definidos no assembly atual.
        /// </summary>
        public static IServiceCollection AddApplicationMapster(
            this IServiceCollection services)
        {
            // Obtém a configuração global do Mapster
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // Faz um scan automático das classes que implementam IRegister no assembly atual
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
            // Cria a instância de Mapper baseada na configuração carregada
            var mapperConfig = new Mapper(typeAdapterConfig);
            // Registra o IMapper como singleton na injeção de dependência
            services.AddSingleton<IMapper>(mapperConfig);

            return services;
        }
    }
}

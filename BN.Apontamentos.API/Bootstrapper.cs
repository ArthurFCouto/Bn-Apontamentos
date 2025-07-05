using Microsoft.OpenApi.Models;

namespace BN.Apontamentos.API
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerGen((data) =>
            {
                data.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "BN.Apontamentos",
                        Version = "v1",
                        Description = "API para gerenciamento de apontamentos de produção",
                    });

                string applicationBasePath = AppContext.BaseDirectory;
                string applicationName = AppDomain.CurrentDomain.FriendlyName;
                string xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    data.IncludeXmlComments(xmlDocumentPath);
                }

                data.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                data.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}

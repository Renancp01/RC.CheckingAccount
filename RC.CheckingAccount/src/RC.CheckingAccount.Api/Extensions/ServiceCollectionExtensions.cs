using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RC.CheckingAccount.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Conta Corrente",
                    Description = "Uma simples exemplo de implementação de API para conta corrente",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Carlos",
                        Email = "renancp91@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/rcp01/"),
                    }
                });
            });
        }
    }
}

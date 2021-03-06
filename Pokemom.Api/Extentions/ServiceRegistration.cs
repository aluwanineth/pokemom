using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemom.Api.Core.Contracts.Repositories;
using Pokemom.Api.Core.Contracts.Services;
using Pokemom.Api.Core.Repositories;
using Pokemom.Api.Core.Services;
using Pokemom.Api.Dtos;

namespace Pokemom.Api.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiResource>(configuration.GetSection("apiResource"));
            services.AddScoped<IPokemomRepository, PokemomRepository>();
            services.AddScoped<IPokemomService, PokemomService>();
            return services;
        }
    }
}

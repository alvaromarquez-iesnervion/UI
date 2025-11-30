using Microsoft.Extensions.DependencyInjection;
using Domain.interfaces.repos;
using Domain.interfaces.usecases;
using Domain.usecases;
using Data.repos;
using Infrastructure.Repositories;

namespace CompositionRoot.Dependencias
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services)
        {

            // Registrar repositorios
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            // Registrar casos de uso
            services.AddScoped<IPersonaRepositoryUsecase, PersonaRepositoryUsecase>();
            services.AddScoped<IDepartamentoRepositoryUsecase, DepartamentoRepositoryUsecase>();


            return services;
        }
    }
}
using FluentValidation;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Services;
using ProdutosApp.Application.Validations;
using ProdutosApp.Domain.Interfaces;
using ProdutosApp.Infra.Data.Repositories;

namespace ProdutosApp.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProdutosAppService, ProdutoAppService>();
            services.AddTransient<IProdutosRepository, ProdutosRepository>();

            services.AddScoped<IValidator<ProdutoRequestDto>, ProdutoValidator>();
        }
    }
}

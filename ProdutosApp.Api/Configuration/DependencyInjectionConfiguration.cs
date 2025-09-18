using FluentValidation;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Services;
using ProdutosApp.Application.Validations;

namespace ProdutosApp.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProdutosAppService, ProdutoAppService>();
            services.AddScoped<IValidator<ProdutoRequestDto>, ProdutoValidator>();
        }
    }
}

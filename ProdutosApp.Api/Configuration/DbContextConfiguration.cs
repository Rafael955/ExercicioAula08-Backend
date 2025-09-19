using Microsoft.EntityFrameworkCore;
using ProdutosApp.Infra.Data.Contexts;

namespace ProdutosApp.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            // Obtém a string de conexão do appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Registra o DataContext com a string de conexão
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}

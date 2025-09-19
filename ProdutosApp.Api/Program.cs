using FluentValidation;
using ProdutosApp.Api.Configuration;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbContext();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDependencyInjection();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

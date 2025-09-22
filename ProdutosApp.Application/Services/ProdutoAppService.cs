using FluentValidation;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Dtos.Response;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Mappers;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Services
{
    public class ProdutoAppService(IValidator<ProdutoRequestDto> validator, IProdutosRepository produtosRepository) : IProdutosAppService
    {
        public ProdutoResponseDto CriarProduto(ProdutoRequestDto request)
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var produto = produtosRepository.GetProductByName(request.Nome);

            if (produto != null)
                throw new ApplicationException("Não será possível alterar pois já existe um produto cadastrado com este nome.");

            produto = new Produto(request.Nome, request.Preco, request.Quantidade);

            produtosRepository.AddProduct(produto);

            return produto.ToResponseDto();
        }

        public ProdutoResponseDto AlterarProduto(Guid id, ProdutoRequestDto request)
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var produto = produtosRepository.GetProductByName(request.Nome);

            if(produto != null && produto.IdProduto != id)
                throw new ApplicationException("Não será possível alterar pois já existe um produto cadastrado com este nome.");

            produto = produtosRepository.GetProductById(id);

            if(produto == null)
                throw new ApplicationException("Produto não encontrado.");

            produto.AlterarProduto(request.Nome, request.Preco, request.Quantidade);

            produtosRepository.UpdateProduct(produto);

            return produto.ToResponseDto();
        }

        public ProdutoResponseDto ExcluirProduto(Guid id)
        {
            var produto = produtosRepository.GetProductById(id);

            if (produto == null)
                throw new ApplicationException("Produto não encontrado.");

            produtosRepository.DeleteProduct(produto);

            return produto.ToResponseDto();
        }

        public ProdutoResponseDto? ObterProdutoPorId(Guid id)
        {
            var produto = produtosRepository.GetProductById(id);

            if (produto == null)
                throw new ApplicationException("Produto não encontrado.");

            return produto.ToResponseDto();
        }

        public List<ProdutoResponseDto>? ObterTodosProdutos()
        {
            var produtos = produtosRepository.GetAllProducts();

            return produtos?.Select(x => x.ToResponseDto()).ToList();
        }
    }
}

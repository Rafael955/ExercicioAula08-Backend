using FluentValidation;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Dtos.Response;
using ProdutosApp.Application.Interfaces;
using ProdutosApp.Application.Mappers;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Services
{
    public class ProdutoAppService(IValidator<ProdutoRequestDto> validator) : IProdutosAppService
    {
        public ProdutoResponseDto CriarProduto(ProdutoRequestDto request)
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var produto = new Produto(request.Nome, request.Preco, request.Quantidade);

            return produto.ToResponseDto();
        }

        public ProdutoResponseDto AlterarProduto(Guid id, ProdutoRequestDto request)
        {
            throw new NotImplementedException();
        }

        public ProdutoResponseDto ExcluirProduto(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProdutoResponseDto? ObterProdutoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoResponseDto>? ObterTodosProdutos()
        {
            throw new NotImplementedException();
        }
    }
}

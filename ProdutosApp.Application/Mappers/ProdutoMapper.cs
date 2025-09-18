using ProdutosApp.Application.Dtos.Response;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Mappers
{
    public static class ProdutoMapper
    {
        public static ProdutoResponseDto ToResponseDto(this Produto produto)
        {
            return new ProdutoResponseDto
            {
                IdProduto = produto.IdProduto,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            };
        }
    }
}

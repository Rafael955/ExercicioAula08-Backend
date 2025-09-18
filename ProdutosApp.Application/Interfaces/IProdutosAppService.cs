using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Interfaces
{
    public interface IProdutosAppService
    {
        ProdutoResponseDto CriarProduto(ProdutoRequestDto request);

        ProdutoResponseDto AlterarProduto(Guid id, ProdutoRequestDto request);

        ProdutoResponseDto ExcluirProduto(Guid id);

        ProdutoResponseDto? ObterProdutoPorId(Guid id);

        List<ProdutoResponseDto>? ObterTodosProdutos();
    }
}

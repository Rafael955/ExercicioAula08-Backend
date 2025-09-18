using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Dtos.Response
{
    public class ProdutoResponseDto
    {
        public Guid IdProduto { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}

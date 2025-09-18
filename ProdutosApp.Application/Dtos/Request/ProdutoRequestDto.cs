using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Dtos.Request
{
    public class ProdutoRequestDto
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}

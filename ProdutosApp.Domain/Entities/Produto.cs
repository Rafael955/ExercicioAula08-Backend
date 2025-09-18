using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; private set; }

        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public int Quantidade { get; private set; }

        //Construtor para o EF
        private Produto(Guid id, string nome, decimal preco, int quantidade)
        {
            IdProduto = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto(string nome, decimal preco, int quantidade)
        {
            ValidacoesProduto(nome, preco, quantidade);

            IdProduto = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public void AlterarProduto(string nome, decimal preco, int quantidade)
        {
            ValidacoesProduto(nome, preco, quantidade);

            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        private void ValidacoesProduto(string nome, decimal preco, int quantidade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ApplicationException("O nome do produto é obrigatório.");

            if (nome.Length < 5)
                throw new ApplicationException("O nome deverá ter no mínimo 5 caracteres.");

            if (nome.Length > 150)
                throw new ApplicationException("O nome deverá ter no máximo 150 caracteres.");


            if (preco < 0)
                throw new ApplicationException("O preço do produto deve ser maior que zero.");


            if (quantidade < 0)
                throw new ApplicationException("A quantidade não pode ser negativa.");

            if (quantidade > 500)
                throw new ApplicationException("A quantidade máxima no estoque é de 500 unidades.");
        }
    }
}

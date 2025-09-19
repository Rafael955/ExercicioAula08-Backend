using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        public void AddProduct(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto? GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Produto>? GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}

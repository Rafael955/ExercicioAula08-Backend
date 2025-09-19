using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces
{
    public interface IProdutosRepository
    {
        void AddProduct(Produto produto);

        void UpdateProduct(Produto produto);

        void DeleteProduct(Produto produto);

        Produto? GetProductById(Guid id);

        List<Produto>? GetAllProducts();
    }
}

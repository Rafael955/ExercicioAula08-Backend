using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly DataContext _context;

        public ProdutosRepository(DataContext context)
        {
            _context = context;
        }

        public void AddProduct(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduct(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();
        }

        public void DeleteProduct(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }

        public Produto? GetProductById(Guid id)
        {
            return _context.Set<Produto>()
                .SingleOrDefault(p => p.IdProduto == id);
        }

        public List<Produto>? GetAllProducts()
        {
            return _context.Set<Produto>().AsNoTracking().ToList();
        }

        public Produto? GetProductByName(string productName)
        {
            return _context.Set<Produto>()
                .FirstOrDefault(p => p.Nome.ToUpper() == productName.ToUpper());
        }
    }
}

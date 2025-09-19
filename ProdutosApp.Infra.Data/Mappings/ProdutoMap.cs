using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;

namespace ProdutosApp.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("ID_PRODUTO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(p => p.Nome).IsUnique();
        }
    }
}

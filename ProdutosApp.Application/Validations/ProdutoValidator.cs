using FluentValidation;
using ProdutosApp.Application.Dtos.Request;
using ProdutosApp.Domain.Entities;

namespace ProdutosApp.Application.Validations
{
    public class ProdutoValidator : AbstractValidator<ProdutoRequestDto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MinimumLength(5).WithMessage("O nome deverá ter no mínimo 5 caracteres.")
                .MaximumLength(150).WithMessage("O nome deverá ter no máximo 150 caracteres.");

            RuleFor(p => p.Preco)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.")
                .PrecisionScale(8, 2, true).WithMessage("O preço do produto deve ter no máximo 8 digitos com 2 casas decimais.");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.")
                .LessThanOrEqualTo(500).WithMessage("A quantidade máxima no estoque é de 500 unidades.");
        }
    }
}

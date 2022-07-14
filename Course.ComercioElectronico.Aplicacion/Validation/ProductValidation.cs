using Course.ComercioElectronico.Aplicacion.DTOs;
using FluentValidation;

namespace Course.ComercioElectronico.Aplicacion.Validation
{
    public class ProductValidation : AbstractValidator<CreateProductDto>
    {
        public ProductValidation()
        {
            RuleFor(r => r.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(15)
                .MaximumLength(256);
            RuleFor(r => r.Price)
                .GreaterThan(0);
            RuleFor(r => r.ProductyTypeId)
                .NotNull()
                .NotEmpty();

        }
    }
}

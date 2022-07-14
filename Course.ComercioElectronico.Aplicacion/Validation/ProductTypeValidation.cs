using Course.ComercioElectronico.Dominio.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Validation
{
    public class ProductTypeValidation : AbstractValidator<ProductType>
    {
        public ProductTypeValidation()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(250);
        }
    }
}

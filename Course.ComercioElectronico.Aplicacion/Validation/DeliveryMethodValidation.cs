using Course.ComercioElectronico.Aplicacion.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Validation
{
    public class DeliveryMethodValidation : AbstractValidator<CreateDeliveryMethodDto>
    {
        public DeliveryMethodValidation()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256)
                .MinimumLength(5);
        }
    }
}

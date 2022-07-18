using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Validation
{
    public class BrandValidation : AbstractValidator<CreateBrandDto>
    {
        public BrandValidation()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull();
                //Regex validation numbers, letters, -
                //.Matches("^[a-zA-Z0-9-]*$");
            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256)
                .MinimumLength(10);
            
        }
    }
}

﻿using Course.ComercioElectronico.Aplicacion.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Validation
{
    public class OrderValidation : AbstractValidator<CreateOrderDto>
    {
        public OrderValidation()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull();
        }
    }
}
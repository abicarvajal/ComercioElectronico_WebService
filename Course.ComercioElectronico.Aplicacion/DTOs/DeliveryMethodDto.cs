﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.DTOs
{
    public class DeliveryMethodDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

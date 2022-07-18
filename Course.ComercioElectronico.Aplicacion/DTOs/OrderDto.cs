using Course.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.DTOs
{
    public class OrderDto
    {

        public string Code { get; set; }

        public string DeliveryMethodId { get; set; }

        public string DeliveryMethodName { get; set; }
    }
}

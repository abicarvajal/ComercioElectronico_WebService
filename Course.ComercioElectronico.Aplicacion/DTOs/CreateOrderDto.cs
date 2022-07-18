using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.DTOs
{
    public class CreateOrderDto
    {
        public string Code { get; set; }
        public string DeliveryMethodId { get; set; }
        public List<CreateCartItemDto> ItemsToCart { get; set; }
    }
}

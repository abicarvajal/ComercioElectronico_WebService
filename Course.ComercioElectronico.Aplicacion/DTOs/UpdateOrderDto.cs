using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.DTOs
{
    public class UpdateOrderDto
    {
        public string DeliveryMethodId { get; set; }
        public List<CreateCartItemDto> ItemsToCart { get; set; }
    }
}

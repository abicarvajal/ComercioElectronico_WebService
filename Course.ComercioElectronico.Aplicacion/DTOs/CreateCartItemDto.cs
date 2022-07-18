using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.DTOs
{
    public class CreateCartItemDto
    {
        public string Code { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

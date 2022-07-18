using Course.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Entities
{
    public class CartItemOrder : BaseCatalogEntity
    {
        public Product? Product { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public CartOrder? CartOrder { get; set; }

        public string CartOrderId { get; set; }
        
    }
}

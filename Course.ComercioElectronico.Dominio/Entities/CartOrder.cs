using Course.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Entities
{
    public class CartOrder : BaseCatalogEntity
    {
        public DeliveryMethod? DeliveryMethod { get; set; }

        public string DeliveryMethodId { get; set; }

        private readonly List<CartItemOrder>? _productDetail = new List<CartItemOrder>();

        public IReadOnlyCollection<CartItemOrder>? ProductDetail => _productDetail;
    }
}

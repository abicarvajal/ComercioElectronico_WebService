using Course.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Entities
{
    public class DeliveryMethod : BaseCatalogEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryTime { get; set; }
    }
}

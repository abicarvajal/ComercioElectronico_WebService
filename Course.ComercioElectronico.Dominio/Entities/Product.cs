using Course.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Entities
{
    public class Product : BaseBusinessEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductType? ProductType { get; set; }

        //Relationship one-to-many
        public string ProductTypeId { get; set; }

        public Brand? Brand { get; set; }

        //Mapping of relationship one-to-many
        public string BrandId { get; set; }

        public int Stock { get; set; }

    }
}

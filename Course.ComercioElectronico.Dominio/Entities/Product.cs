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

        //esto nos ayuda a hacer el mapeo en la relacion de uno a muchos
        public string ProductTypeId { get; set; }

        public Brand? Brand { get; set; }

        //esto nos ayuda a hacer el mapeo en la relacion de uno a muchos
        public string BrandId { get; set; }
    }
}

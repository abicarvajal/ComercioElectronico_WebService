using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public ProductTypeRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<ProductType>> GetAsync()
        {
            return await context.ProductType.ToListAsync();
        }

        public async Task<ProductType> GetByIdAsync(string code)
        {
            return await context.ProductType.FindAsync(code);
        }
    }
}

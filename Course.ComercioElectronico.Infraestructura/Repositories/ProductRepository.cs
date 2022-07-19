using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public ProductRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<Product>> GetAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await context.Product.FindAsync(id);
        }
    }
}

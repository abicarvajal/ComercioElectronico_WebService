using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public BrandRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<Brand>> GetAsync()
        {

            return await context.Brand.ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            return await context.Brand.FindAsync(id);
        }
    }
}

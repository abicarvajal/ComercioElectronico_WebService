using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public CalculationRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }

        public IQueryable<CartOrder> GetQueryable()
        {
            return context.Set<CartOrder>().AsQueryable();
        }

        public IQueryable<CartItemOrder> GetQueryableItems()
        {
            return context.Set<CartItemOrder>().AsQueryable();
        }
    }
}

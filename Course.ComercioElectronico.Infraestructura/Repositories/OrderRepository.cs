using Course.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public OrderRepository(ComercioElectronicoDBContext context)
        {
            //context = new ComercioElectronicoDBContext();
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

        public async Task CreateCartOrderAsync(CartOrder cartOrder)
        {
            context.Set<CartOrder>().AddAsync(cartOrder);

            await context.SaveChangesAsync();
        }

        public async Task CreateCartItemOrderAsync(CartItemOrder cartItemOrder)
        {
            context.Set<CartItemOrder>().AddAsync(cartItemOrder);

            await context.SaveChangesAsync();
        }
    }
}

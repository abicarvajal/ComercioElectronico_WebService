using Course.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Repositories
{
    public interface ICalculationRepository
    {
        IQueryable<CartOrder> GetQueryable();
        IQueryable<CartItemOrder> GetQueryableItems();
    }
}

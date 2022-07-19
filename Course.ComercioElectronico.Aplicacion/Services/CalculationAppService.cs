using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class CalculationAppService : ICalculationAppService
    {
        protected ICalculationRepository repository { get; set; }

        public CalculationAppService(ICalculationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<decimal> CalculateTotalOfOrder(string id)
        {
            decimal resultado = 0;
            var queryItems = repository.GetQueryableItems();
            var cartOrderItems = await queryItems.Where(x => x.CartOrderId == id)
                .Select(x => x.Product.Price*x.Quantity).ToListAsync();
 
            foreach (var item in cartOrderItems)
            {
                resultado += item;
            }

            return resultado;
        }
    }
}

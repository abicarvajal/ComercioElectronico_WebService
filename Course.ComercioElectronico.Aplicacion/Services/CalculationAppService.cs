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

        public async Task<DetailOrderDto> CalculateTotalOfOrder(string id)
        {
            decimal total = 0;
            var queryItems = repository.GetQueryableItems();
            var cartOrderItems = await queryItems.Where(x => x.CartOrderId == id)
                .Select(x => x.Product.Price*x.Quantity).ToListAsync();
            var cartOrderItemsDetail = await queryItems.Where(x => x.CartOrderId == id)
                .Select(x => new ItemDetailDto
                {
                    ProductName = x.Product.Name,
                    ProductPrice = x.Product.Price,
                    Quantity = x.Quantity
                }).ToListAsync();

            List<ItemDetailDto> itemDetail = new List<ItemDetailDto>();
            foreach (var item in cartOrderItemsDetail)
            {
                itemDetail.Add(item);
            }
 
            foreach (var item in cartOrderItems)
            {
                total += item;
            }

            DetailOrderDto detailOrderDto = new DetailOrderDto { itemDetail = itemDetail, total=total };

            return detailOrderDto;
        }
    }
}

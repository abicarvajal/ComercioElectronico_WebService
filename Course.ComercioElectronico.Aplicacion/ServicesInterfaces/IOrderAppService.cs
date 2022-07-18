using Course.ComercioElectronico.Aplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IOrderAppService
    {
        Task<ICollection<OrderDto>> GetAllAsync();
        Task<ICollection<CartItemDto>> GetAllItemsAsync();
        Task<OrderDto> GetByIdAsync(string id);
        //Task<OrderDto> UpdateAsync(CreateProductDto product, Guid id);
        //Task<bool> Delete(string id);
        Task<OrderDto> CreateAsync(CreateOrderDto createrderDto);
        //Task<ResultPagination<ProductDto>> GetListAsync(string? search = "", int limit = 10, int offset = 0, string sort = "Name", string order = "asc");
    }
}

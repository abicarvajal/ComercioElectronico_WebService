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
        /// <summary>
        /// Get all orders with its products
        /// </summary>
        /// <returns></returns>
        Task<ICollection<OrderDto>> GetAllAsync();

        /// <summary>
        /// Get all items of all orders
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CartItemDto>> GetAllItemsAsync();

        /// <summary>
        /// Get an order and items by ID of the order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderDto> GetByIdAsync(string id);

        /// <summary>
        /// Update an order and its items
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderDto> UpdateAsync(UpdateOrderDto createOrderDto, string id);

        //Task<bool> Delete(string id);
        /// <summary>
        /// Method to create and Order with its item products
        /// </summary>
        /// <param name="createrderDto"></param>
        /// <returns></returns>
        Task<OrderDto> CreateAsync(CreateOrderDto createrderDto);

        //Task<ResultPagination<ProductDto>> GetListAsync(string? search = "", int limit = 10, int offset = 0, string sort = "Name", string order = "asc");
    }
}

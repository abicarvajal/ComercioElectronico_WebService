using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
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
        /// Create and Order with its item products
        /// </summary>
        /// <param name="createrderDto"></param>
        /// <returns></returns>
        Task<OrderDto> CreateAsync(CreateOrderDto createrderDto);

        /// <summary>
        /// Pagination of all orders
        /// </summary>
        /// <param name="search"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<ResultPagination<OrderDto>> GetListAsync(int limit = 10, int offset = 0, string sort = "Code", string order = "asc");

        /// <summary>
        /// Get filtering by brandId and OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        Task<List<IEnumerable<CartItemDto>>> GetByBrandAndId(string id, string brandId);

        /// <summary>
        /// Get filtering by ProductTypeId and OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        Task<List<IEnumerable<CartItemDto>>> GetByProductTypeAndId(string id, string productTypeId);

    }
}

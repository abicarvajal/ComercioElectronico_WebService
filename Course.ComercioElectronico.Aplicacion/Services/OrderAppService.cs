using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class OrderAppService : IOrderAppService
    {
        protected IOrderRepository repository { get; set; }

        public OrderAppService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<OrderDto>> GetAllAsync()
        {
            var query = this.repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false)
                .Select(x => new OrderDto
                    {
                        DeliveryMethodId = x.DeliveryMethodId,
                        Code = x.Code,
                        DeliveryMethodName = x.DeliveryMethod.Description
                    }
                );
            
            return result.ToList();
          
        }

        public async Task<ICollection<CartItemDto>> GetAllItemsAsync()
        {
            var query = this.repository.GetQueryableItems();
            var result = query.Where(x => x.IsDeleted == false)
                .Select(x => new CartItemDto
                {
                    Code = x.Code,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    CartOrderId = x.CartOrderId,
                }
                );
            return result.ToList();
        }
        /// <summary>
        /// Method to create and Order with its item products
        /// </summary>
        /// <param name="createrderDto"></param>
        /// <returns></returns>
        public async Task<OrderDto> CreateAsync(CreateOrderDto createrderDto)
        {
            var newOrder = new CartOrder
            {
                Code = createrderDto.Code,
                DeliveryMethodId = createrderDto.DeliveryMethodId,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            await this.repository.CreateCartOrderAsync(newOrder);

            foreach (var item in createrderDto.ItemsToCart)
            {
                var newCartItem = new CartItemOrder
                {
                    Code = item.Code,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    CartOrderId = createrderDto.Code,
                    CreationDate = DateTime.Now,
                    IsDeleted = false
                };

                await this.repository.CreateCartItemOrderAsync(newCartItem);
            }

            return await GetByIdAsync(createrderDto.Code);
            
        }

        public async Task<OrderDto> GetByIdAsync(string id)
        {
            var query = this.repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false && x.Code == id)
                .Select(x => new OrderDto
                {
                    DeliveryMethodId = x.DeliveryMethodId,
                    Code = x.Code,
                    DeliveryMethodName = x.DeliveryMethod.Description
                }
                );

            return await result.SingleOrDefaultAsync();
        }
    }
}

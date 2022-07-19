﻿using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderAppService
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost]
        public Task<OrderDto> CreateAsync(CreateOrderDto createrderDto)
        {
            return _orderAppService.CreateAsync(createrderDto);
        }

        [HttpGet]
        public Task<ICollection<OrderDto>> GetAllAsync()
        {
            return _orderAppService.GetAllAsync();
        }

        [HttpGet("OrderItems")]
        public Task<ICollection<CartItemDto>> GetAllItemsAsync()
        {
            return _orderAppService.GetAllItemsAsync();
        }
        [HttpGet("{id}/brand/{brandId}")]
        public Task<List<IEnumerable<CartItemDto>>> GetByBrandAndId(string id, string brandId)
        {
            return _orderAppService.GetByBrandAndId(id, brandId);
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(string id)
        {
            return _orderAppService.GetByIdAsync(id);
        }

        [HttpGet("{id}/productType/{productTypeId}")]
        public Task<List<IEnumerable<CartItemDto>>> GetByProductTypeAndId(string id, string productTypeId)
        {
            return _orderAppService.GetByProductTypeAndId(id, productTypeId);
        }

        [HttpGet("OrderPagination")]
        public Task<ResultPagination<OrderDto>> GetListAsync(int limit = 10, int offset = 0, string sort = "Code", string order = "asc")
        {
            return _orderAppService.GetListAsync(limit, offset, sort, order);
        }

        [HttpPut]
        public Task<OrderDto> UpdateAsync(UpdateOrderDto createOrderDto, string id)
        {
            return _orderAppService.UpdateAsync(createOrderDto, id);
        }
    }
}

using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
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

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(string id)
        {
            return _orderAppService.GetByIdAsync(id);
        }
    }
}

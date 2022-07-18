using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase, IDeliveryMethodAppService
    {
        private readonly IDeliveryMethodAppService _deliveryMethodAppService;

        public DeliveryMethodController(IDeliveryMethodAppService deliveryMethodAppService)
        {
            _deliveryMethodAppService = deliveryMethodAppService;
        }

        [HttpPost]
        public Task<DeliveryMethodDto> CreateAsync(CreateDeliveryMethodDto deliveryMethod)
        {
            return _deliveryMethodAppService.CreateAsync(deliveryMethod);
        }

        [HttpDelete]
        public Task<bool> Delete(string id)
        {
            return _deliveryMethodAppService.Delete(id);
        }

        [HttpGet]
        public Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            return _deliveryMethodAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<DeliveryMethodDto> GetByIdDtoAsync(string id)
        {
            return _deliveryMethodAppService.GetByIdDtoAsync(id);
        }

        [HttpPut]
        public Task<DeliveryMethodDto> UpdateAsync(DeliveryMethodDto deliveryMethod)
        {
            return _deliveryMethodAppService.UpdateAsync(deliveryMethod);
        }
    }
}

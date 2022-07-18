using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase, IBrandAppService
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        [HttpGet]
        public Task<ICollection<BrandDto>> GetAllAsync()
        {
            return _brandAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<BrandDto> GetByIdDtoAsync(string id)
        {
            return _brandAppService.GetByIdDtoAsync(id);
        }

        [HttpPost]
        public Task<BrandDto> CreateAsync(CreateBrandDto brand)
        {
            return _brandAppService.CreateAsync(brand);
        }

        [HttpPut]
        public Task<BrandDto> UpdateAsync(BrandDto brand)
        {
            return _brandAppService.UpdateAsync(brand);
        }

        [HttpDelete]
        public Task<bool> Delete(string id)
        {
            return _brandAppService.Delete(id);
        }

    }
}

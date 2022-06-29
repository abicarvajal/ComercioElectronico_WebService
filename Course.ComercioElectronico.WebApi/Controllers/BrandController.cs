using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
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
        public Task<ICollection<Brand>> GetAsync()
        {
            return _brandAppService.GetAsync();
        }

        [HttpGet("{id}")]
        public Task<Brand> GetByIdAsync(string id)
        {
            return _brandAppService.GetByIdAsync(id);
        }
    }
}

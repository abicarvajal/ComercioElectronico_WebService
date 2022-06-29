using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductAppService
    {
        private readonly IProductAppService productAplication;

        public ProductController(IProductAppService productAplication)
        {
            this.productAplication = productAplication;
        }

        [HttpGet]
        public Task<ICollection<Product>> GetAsync()
        {
            return productAplication.GetAsync();
        }

        [HttpGet("{id}")]
        public Task<Product> GetByIdAsync(Guid id)
        {
            return productAplication.GetByIdAsync(id);
        }
    }
}

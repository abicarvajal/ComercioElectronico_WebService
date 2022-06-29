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

        [HttpPost]
        public Task<Product> CreateAsync(Product product)
        {
            return productAplication.CreateAsync(product);
        }

        [HttpDelete]
        public Task<bool> Delete(Product product)
        {
            return productAplication.Delete(product);
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

        [HttpPut]
        public Task<Product> UpdateAsync(Product product)
        {
            return productAplication.UpdateAsync(product);
        }
    }
}

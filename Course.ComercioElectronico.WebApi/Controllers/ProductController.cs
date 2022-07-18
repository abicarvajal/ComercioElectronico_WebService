using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
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
        public Task<ICollection<ProductDto>> GetAllAsync()
        {
            return productAplication.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            return productAplication.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<ProductDto> CreateAsync(CreateProductDto product)
        {
            return productAplication.CreateAsync(product);
        }

        [HttpPut("{id}")]
        public Task<ProductDto> UpdateAsync(CreateProductDto product,Guid id)
        {
            return productAplication.UpdateAsync(product,id);
        }

        [HttpDelete("{id}")]
        public Task<bool> Delete(Guid id)
        {
            return productAplication.Delete(id);
        }

        [HttpGet]
        [Route("search")]
        public Task<ResultPagination<ProductDto>> GetListAsync(string search = "", int limit = 10, int offset = 0, string sort = "Name", string order = "asc")
        {
            return productAplication.GetListAsync(search, limit, offset, sort, order);
        }
    }
}
